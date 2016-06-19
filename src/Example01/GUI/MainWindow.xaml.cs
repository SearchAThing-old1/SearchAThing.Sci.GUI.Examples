﻿#region SearchAThing.Sci.GUI, Copyright(C) 2016 Lorenzo Delana, License under MIT
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

using System;
using System.Windows;

namespace SearchAThing.Sci.GUI.Examples
{

    public partial class MainWindow : Window
    {

        Global global { get { return Global.Instance; } }

        public MainWindow()
        {
            InitializeComponent();

            /*
            physicalQuantityCbox.ItemsSource = PQCollection.PhysicalQuantities;
            
            sciTextBox.Value = new Measure(123.4, MUCollection.Length.mm);
            sciTextBox.LostFocus += SciTextBox_LostFocus;
            sciTextBox.ValueChanged += SciTextBox_ValueChanged;*/
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            global.Status.Clear();
            await global.CheckDBConnection();
            if (global.DBConnectionStatus == DBConnectionStatusEnum.Successful)
            {
                global.OpenedProject = await global.LoadProject();
            }
        }

        private void SciTextBox_ValueChanged(SciTextBox sender, Measure measure)
        {
            //logTbox.Text = measure.ToString();
        }

        private void SciTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine($"measure = [{sciTextBox.Value}]");
        }     

    }

}