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

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace SearchAThing.Sci.GUI.Examples
{

    [BsonIgnoreExtraElements]
    public class Project : INotifyPropertyChanged
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        #region INotifyPropertyChanged [propce]       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SendPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region A [propc]
        Measure _A;
        public Measure A
        {
            get
            {
                if (_A == null) _A = new Measure(1.0, MUCollection.Length.m);
                return _A;
            }
            set
            {
                if (_A != value)
                {
                    _A = value;
                    SendPropertyChanged("A");                    
                }
            }
        }
        #endregion

        #region B [propc]
        Measure _B;
        public Measure B
        {
            get
            {
                if (_B == null) _B = new Measure(1.0, MUCollection.Length.mm);
                return _B;
            }
            set
            {
                if (_B != value)
                {
                    _B = value;
                    SendPropertyChanged("B");
                }
            }
        }
        #endregion       

        #region Var1 [propc]
        Measure _Var1;
        public Measure Var1
        {
            get
            {
                if (_Var1 == null) _Var1 = new Measure(1, MUCollection.Force.N);
                return _Var1;
            }
            set
            {
                if (_Var1 != value)
                {
                    _Var1 = value;
                    SendPropertyChanged("Var1");
                }
            }
        }
        #endregion

        #region Var2 [propc]
        Measure _Var2;
        public Measure Var2
        {
            get
            {
                if (_Var2 == null) _Var2 = new Measure(1, MUCollection.Pressure.Pa);
                return _Var2;
            }
            set
            {
                if (_Var2 != value)
                {
                    _Var2 = value;
                    SendPropertyChanged("Var2");
                }
            }
        }
        #endregion

        #region Var3 [propc]
        Measure _Var3;
        public Measure Var3
        {
            get
            {
                if (_Var3 == null) _Var3 = new Measure(1, MUCollection.Time.sec);
                return _Var3;
            }
            set
            {
                if (_Var3 != value)
                {
                    _Var3 = value;
                    SendPropertyChanged("Var3");
                }
            }
        }
        #endregion

    }

}
