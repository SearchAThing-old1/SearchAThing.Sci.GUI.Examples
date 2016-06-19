#region SearchAThing.Sci.GUI, Copyright(C) 2016 Lorenzo Delana, License under MIT
/*
* The MIT License(MIT)
* Copyright(c) 2016 Lorenzo Delana, https://searchathing.com
*
* Permission is hereby granted, free of charge, to any person obtaining a
* copy of this software and associated documentation files (the "Software"),
* to deal in the Software without restriction, including without limitation
* the rights to use, copy, modify, merge, publish, distribute, sublicense,
* and/or sell copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
* DEALINGS IN THE SOFTWARE.
*/
#endregion

using MongoDB.Driver;
using SearchAThing.Wpf.Toolkit;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SearchAThing.Sci.GUI.Examples
{

    public partial class Global
    {

        IMongoClient dbClient;
        IMongoDatabase db;

        #region DBConnectionAvailable [propc]
        bool _DBConnectionAvailable;
        public bool DBConnectionAvailable
        {
            get
            {
                return _DBConnectionAvailable;
            }
            set
            {
                if (_DBConnectionAvailable != value)
                {
                    _DBConnectionAvailable = value;
                    SendPropertyChanged("DBConnectionAvailable");
                }
            }
        }
        #endregion

        #region DBConnectionCheckInProgress [propcn]
        bool _DBConnectionCheckInProgress;
        public bool DBConnectionCheckInProgress
        {
            get
            {
                return _DBConnectionCheckInProgress;
            }
            set
            {
                if (_DBConnectionCheckInProgress != value)
                {
                    _DBConnectionCheckInProgress = value;
                    SendPropertyChanged("DBConnectionCheckInProgress");
                }
            }
        }
        #endregion

        #region DBConnectionStatus [propc]
        DBConnectionStatusEnum _DBConnectionStatus;
        public DBConnectionStatusEnum DBConnectionStatus
        {
            get
            {
                return _DBConnectionStatus;
            }
            set
            {
                if (_DBConnectionStatus != value)
                {
                    _DBConnectionStatus = value;
                    SendPropertyChanged("DBConnectionStatus");

                    DBConnectionAvailable = value == DBConnectionStatusEnum.Successful;
                    DBConnectionCheckInProgress = value == DBConnectionStatusEnum.Checking;
                }
            }
        }
        #endregion

        internal async Task CheckDBConnection()
        {
            await Task.Run(() =>
            {
                var st = Status.NewStatus("checking db connection...");

                DBConnectionStatus = DBConnectionStatusEnum.Checking;

                try
                {
                    dbClient = new MongoClient(AppSettings.MongoDBConnectionString);
                    db = dbClient.GetDatabase(AppSettings.DBName);
                    try
                    {
                        using (var ct = new CancellationTokenSource(TimeSpan.FromSeconds(2)))
                        {
                            db.ListCollections(null, ct.Token);
                        }

                        DBConnectionStatus = DBConnectionStatusEnum.Successful;
                    }
                    catch (OperationCanceledException)
                    {
                        DBConnectionStatus = DBConnectionStatusEnum.Failed;
                    }
                }
                catch
                {
                    DBConnectionStatus = DBConnectionStatusEnum.Failed;
                }
                Status.ReleaseStatus(st);
            });
        }

    }

    public enum DBConnectionStatusEnum
    {
        Unknown,
        Checking,
        Failed,
        Successful
    }

}
