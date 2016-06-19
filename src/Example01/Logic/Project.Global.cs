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

        internal async Task<Project> LoadProject()
        {
            return await Task.Run(() =>
            {
                Project prj = null;
                var st = Status.NewStatus("loading project...");
                try
                {
                    var coll = db.GetCollection<Project>("Project");
                    prj = coll.Find(x => true).FirstOrDefault();
                    if (prj == null)
                    {
                        prj = new Project();
                        coll.InsertOne(prj);
                    }
                }
                catch
                {
                }
                Status.ReleaseStatus(st);

                return prj;
            });
        }

        internal async Task SaveProject()
        {
            await Task.Run(() =>
            {
                var st = Status.NewStatus("saving project...");
                try
                {
                    var coll = db.GetCollection<Project>("Project");                    
                    coll.ReplaceOne((x) => x.Id == OpenedProject.Id, OpenedProject);
                }
                catch
                {
                }
                Status.ReleaseStatus(st);
            });
        }

    }

}
