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

namespace Stimulsoft.Report.Com
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IReportCom
    {
        void ResetReport();

        void PrintReport(int coppies);

        void DesignReport();

        void ShowReport();

        void ShowReportInModalWindow();

        void LoadReport(string fileName);

        void SaveReport(string fileName);

        void RenderReport(bool showProgress);

        void CompileReport();

        void SetVariable(string variableName, object value);

        void SaveAs(int type, string fileName, bool openDocument);
    }
}
