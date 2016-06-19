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

using System.ComponentModel;
using System.Threading.Tasks;

namespace SearchAThing.Sci.GUI.Examples
{

    public class AppSettings : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        Global global { get { return Global.Instance; } }

        public static string Pathfilename
        {
            get
            {
                return System.IO.Path.Combine(Core.Path.AppDataFolder("SearchAThing"), "Settings.xml");
            }
        }

        public async Task Save()
        {
            await Task.Run(() =>
            {
                var st = global.Status.NewStatus("Saving settings...");
                this.Serialize(Pathfilename, false);
                global.Status.ReleaseStatus(st);
            });
        }

        #region MongoDBConnectionString        
        public string MongoDBConnectionString
        {
            get
            {
                return $"mongodb://{DBHostname}:{DBPort}/{DBName}";
            }
        }
        #endregion

        #region DBHostname [propcn]
        string _DBHostname;
        public string DBHostname
        {
            get
            {
                if (_DBHostname == null) _DBHostname = "localhost";
                return _DBHostname;
            }
            set
            {
                if (_DBHostname != value)
                {
                    _DBHostname = value;
                    NotifyPropertyChanged("DBHostname");
                }
            }
        }
        #endregion

        #region DBPort [propcn]
        string _DBPort;
        public string DBPort
        {
            get
            {
                if (_DBPort == null) _DBPort = "27017";
                return _DBPort;
            }
            set
            {
                if (_DBPort != value)
                {
                    _DBPort = value;
                    NotifyPropertyChanged("DBPort");
                }
            }
        }
        #endregion

        #region DBName [propcn]
        string _DBName;
        public string DBName
        {
            get
            {
                if (_DBName == null) _DBName = "SearchAThing_Sci_GUI_Examples_Example01";
                return _DBName;
            }
            set
            {
                if (_DBName != value)
                {
                    _DBName = value;
                    NotifyPropertyChanged("DBName");
                }
            }
        }
        #endregion                 

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
