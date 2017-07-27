#region Copyright (C) 2003-2007 Stimulsoft
/*
{*******************************************************************}
{																	}
{	StimulReport.Net												}
{	Stimulsoft.Report Library										}
{																	}
{	Copyright (C) 2003-2007 Stimulsoft     							}
{	ALL RIGHTS RESERVED												}
{																	}
{	The entire contents of this file is protected by U.S. and		}
{	International Copyright Laws. Unauthorized reproduction,		}
{	reverse-engineering, and distribution of all or any portion of	}
{	the code contained in this file is strictly prohibited and may	}
{	result in severe civil and criminal penalties and will be		}
{	prosecuted to the maximum extent possible under the law.		}
{																	}
{	RESTRICTIONS													}
{																	}
{	THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES			}
{	ARE CONFIDENTIAL AND PROPRIETARY								}
{	TRADE SECRETS OF Stimulsoft										}
{																	}
{	CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON		}
{	ADDITIONAL RESTRICTIONS.										}
{																	}
{*******************************************************************}
*/
#endregion Copyright (C) 2003-2007 Stimulsoft

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using Stimulsoft.Report;
//using Stimulsoft.Report.Export;
using System.Windows.Forms;

namespace Stimulsoft.Report.Com
{
    [ClassInterface(ClassInterfaceType.None)]
    public class ReportCom : IReportCom
    {
        private StiReport report;
        
        internal  StiReport Report
            
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }

        #region Methods for work with Report
        /// <summary>
        /// Calls the designer for the report.
        /// </summary>
        public void DesignReport()
        {
            report.Design();
        }


        /// <summary>
        /// Prints the rendered report. If the report is not rendered then its rendering starts.
        /// </summary>
        /// <param name="coppies">Number of copies to print.</param>
        public void PrintReport(int coppies)
        {
            report.Print(false, (short)coppies);
        }


        /// <summary>
        /// Resets a report to null state.
        /// </summary>
        public void ResetReport()
        {
            StiConfig.Load();
            Stimulsoft.Base.Services.StiService aa = Stimulsoft.Report.StiConfig.Services.GetService(typeof(Stimulsoft.Report.Components.StiText));

            report = new StiReport();

            Stimulsoft.Report.StiConfig.Load();
        }


        /// <summary>
        /// Shows the rendered report. If the report is not rendered then its rendering starts.
        /// </summary>
        public void ShowReport()
        {
            Report.Show();
        }


        /// <summary>
        /// Shows the rendered report in modal window. If the report is not rendered then its rendering starts.
        /// </summary>
        public void ShowReportInModalWindow()
        {
            Report.Show(true);
        }


        /// <summary>
        /// Loads a rendered report from the file.
        /// </summary>
        /// <param name="fileName">The file that contains a rendered report.</fileName>
        public void LoadReport(string fileName)
        {
            Report.Load(fileName);
        }


        /// <summary>
        /// Saves a report template in the file.
        /// </summary>
        /// <param name="fileName">The file to save a report template.</fileName>
        public void SaveReport(string fileName)
        {
            Report.Save(fileName);
        }


        /// <summary>
        /// Renders a report.
        /// </summary>
        /// <param name="showProgress">Show the progress of the rendering of the report or no.</param>
        public void RenderReport(bool showProgress)
        {
            Report.Render(showProgress);
        }


        /// <summary>
        /// Compiles a report.
        /// </summary>
        public void CompileReport()
        {
            Report.Compile();
        }


        /// <summary>
        /// Set Variable
        /// </summary>
        /// <param name="variableName">Name variable</param>
        /// <param name="value">Value variable</param>
        public void SetVariable(string variableName, object value)
        {
            //bool, byte, byte[], char, datetime, timespan, decimal, double
            //guid, short, int, long, object, sbyte, float, string, ushort, iuint, ulong, image
            if (report.CompiledReport != null)
            {
                if (report.CompiledReport[variableName] != null)
                {
                    try
                    {
                        if (report.CompiledReport[variableName].GetType() == typeof(bool)) report.CompiledReport[variableName] = (bool)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(byte)) report.CompiledReport[variableName] = (byte)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(byte[])) report.CompiledReport[variableName] = (byte[])value;
                        if (report.CompiledReport[variableName].GetType() == typeof(char)) report.CompiledReport[variableName] = (char)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(DateTime)) report.CompiledReport[variableName] = (DateTime)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(TimeSpan)) report.CompiledReport[variableName] = (TimeSpan)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(decimal)) report.CompiledReport[variableName] = (decimal)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(double)) report.CompiledReport[variableName] = (double)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(Guid)) report.CompiledReport[variableName] = (Guid)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(short)) report.CompiledReport[variableName] = (short)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(int)) report.CompiledReport[variableName] = (int)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(long)) report.CompiledReport[variableName] = (long)value;
                        //if (report.CompiledReport[variableName].GetType() == typeof(object)) report.CompiledReport[variableName] = (object)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(sbyte)) report.CompiledReport[variableName] = (sbyte)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(float)) report.CompiledReport[variableName] = (float)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(string)) report.CompiledReport[variableName] = (string)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(ushort)) report.CompiledReport[variableName] = (ushort)value;
                        //if (report.CompiledReport[variableName].GetType() == typeof(iuint)) report.CompiledReport[variableName] = (iuint)value;
                        if (report.CompiledReport[variableName].GetType() == typeof(ulong)) report.CompiledReport[variableName] = (ulong)value;
                        //if (report.CompiledReport[variableName].GetType() == typeof(image)) report.CompiledReport[variableName] = (image)value;
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// SaveAs
        /// </summary>
        /// <param name="type">None = 0, Pdf = 1, Xps = 2, HtmlTable = 3, HtmlSpan = 4, Rtf = 5, RtfTable = 5, RtfFrame = 6, RtfWinWord = 7, RtfTabbedText = 8, RtfMode1 = 6, RtfMode2 = 7,	RtfMode3 = 8, Text = 9,	Excel = 10, ExcelXml = 11, Excel2007 = 12, Word2007 = 13, Xml = 14, Csv = 15, ImageGif = 16, ImageBmp = 17,	ImagePng = 18, ImageTiff = 19, ImageJpeg = 20, ImageEmf = 21, Mht = 22,	Dbf = 23, Html = 24</param>
        /// <param name="fileName">The file for a rendered report export.</param>
        /// <param name="openDocument">If is true that open exported document.</param>
        public void SaveAs(int type, string fileName, bool openDocument)
        {
            StiExportFormat exportFormat = (StiExportFormat) type;

            report.ExportDocument(exportFormat, fileName);

            if (openDocument) System.Diagnostics.Process.Start(fileName);
        }
        #endregion

        public ReportCom()
        {
            try
            {
                ResetReport();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static ReportCom()
        {
            StiReport.HideExceptions = false;
        }
    }
}
