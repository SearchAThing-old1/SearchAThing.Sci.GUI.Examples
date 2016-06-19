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

using SearchAThing.Wpf.Toolkit;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace SearchAThing.Sci.GUI.Examples
{

    public partial class Global : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged [propce]       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SendPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region instance
        static Global _Instance;
        public static Global Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Global();
                return _Instance;
            }
        }
        #endregion

        #region app settings
        AppSettings _AppSettings;
        public AppSettings AppSettings
        {
            get
            {
                if (_AppSettings == null)
                {
                    if (File.Exists(AppSettings.Pathfilename))
                    {
                        try
                        {
                            _AppSettings = AppSettings.Pathfilename.DeserializeFile<AppSettings>(false);
                        }
                        catch
                        {
                        }
                    }

                    if (_AppSettings == null) _AppSettings = new AppSettings();
                }
                return _AppSettings;
            }
            set
            {
            }
        }
        #endregion
           
        #region Status [propi]
        StatusManager _Status;
        public StatusManager Status
        {
            get
            {
                if (_Status == null) _Status = new StatusManager();
                return _Status;
            }
            set
            {
            }
        }
        #endregion

        #region OpenedProject [propc]
        Project _OpenedProject;
        public Project OpenedProject
        {
            get
            {
                return _OpenedProject;
            }
            set
            {
                if (_OpenedProject != value)
                {
                    _OpenedProject = value;
                    SendPropertyChanged("OpenedProject");
                }
            }
        }
        #endregion


    }

}
