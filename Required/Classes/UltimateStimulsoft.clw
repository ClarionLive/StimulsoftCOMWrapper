                                MEMBER()

!--------------------------
!ClarionLive! Activex Class Template
!--------------------------

    INCLUDE('EQUATES.CLW')  !for ICON: and BEEP: etc.
! INCLUDE('KeyCodes.CLW')

    INCLUDE('UltimateStimulsoft.INC')

                                MAP
                                END

ustWindow                       WINDOW('Caption'),AT(,,260,100),GRAY,FONT('Microsoft Sans Serif',8)
                                END


!----------------------------------------
UltimateStimulsoft.Construct     PROCEDURE()
!----------------------------------------
    CODE   
    
    SELF.qDataSet                            &= NEW qDataSetType
    
    OPEN(ustWindow)
    ustWindow{PROP:Hide} = TRUE 
    
    SELF.Rpt                       =  CREATE(0, CREATE:OLE)
    SELF.Rpt{PROP:Compatibility  } =  20h                     ! 32 bit
    SELF.Rpt{PROP:TRN            } =  1                       ! Transparent
    SELF.Rpt{PROP:Create         } =  'Stimulsoft.Report.Com.ReportCom'
    SELF.Rpt{PROP:ReportException} =  True
    IF NOT SELF.Rpt{PROP:Object}
        MESSAGE('Report control is not registered!','Info',ICON:Hand)  
        
    END
    
    RETURN

    
!---------------------------------------
UltimateStimulsoft.Destruct      PROCEDURE()
!---------------------------------------
    CODE

    FREE(SELF.qDataSet)
    DISPOSE(SELF.qDataSet)
    
    CLOSE(ustWindow)

!-----------------------------------
UltimateStimulsoft.Init          PROCEDURE(STRING pLicenseKey)
!-----------------------------------
   
    CODE
    
    IF SELF.Server
        SELF.ConnectionString =  ('Data Source=' & CLIP(SELF.Server) & |
                ';Initial Catalog=' & CLIP(SELF.Catalog) & |
                ';Integrated Security=' & CLIP(SELF.TrustedConnection) & |
                ';User ID=' & CLIP(SELF.UserID) & |
                ';Password=' & CLIP(SELF.Password) ) 

    END
    SELF.SetLicenseKey(pLicenseKey)
    
    RETURN
          
    
!-----------------------------------
UltimateStimulsoft.Kill          PROCEDURE()
!-----------------------------------

    CODE

    RETURN

 
    
!-----------------------------------
UltimateStimulsoft.AddVariable          PROCEDURE(STRING pVariableName,STRING pVariableType,STRING pValue)
!----------------------------------- 

    CODE
    
    SELF.Rpt{'AddVariable(' & pVariableName & ',' & pVariableType & ',' & pValue & ')'}


!-----------------------------------
UltimateStimulsoft.AssignVariable        PROCEDURE(STRING pVariableName,STRING pValue)
!-----------------------------------

    CODE
    
    SELF.Rpt{'SetVariable("' & pVariableName & '","' & pValue & '")'}

    
!-----------------------------------
UltimateStimulsoft.ShowReport    PROCEDURE(STRING pReportFileName)
!-----------------------------------
       
LocalCount                          LONG

    CODE
    
    SELF.Rpt{'LoadReport("' & CLIP(pReportFileName) & '")'}  
    
    IF SELF.Server   
        LOOP LocalCount = 1 TO RECORDS(SELF.qDataSet)
            GET(SELF.qDataSet,LocalCount)   
            SELF.Rpt{'ConnectToDatabase("' & CLIP(SELF.qDataSet.DataSet) & '","' & CLIP(SELF.qDataSet.ConnectionString) & '")'}
            
        END
        
    END
    
    SELF.Rpt{'ShowReportInModalWindow'}
    
    
!-----------------------------------
UltimateStimulsoft.ShowDesigner          PROCEDURE(<STRING pReportFileName>)
!-----------------------------------

    CODE 
              
    IF pReportFileName
        SELF.Rpt{'LoadReport("' & CLIP(pReportFileName) & '")'} 
    END
    
    SELF.Rpt{'DesignReport'}
    
    
!---------------------------------------------------------
UltimateStimulsoft.RaiseError    PROCEDURE(STRING pErrorMsg)
!---------------------------------------------------------

    CODE

    RETURN   
    
    
!---------------------------------------------------------
UltimateStimulsoft.ClearDataSetCollection        PROCEDURE()
!---------------------------------------------------------

    CODE
    
    FREE(SELF.qDataSet)

    
!---------------------------------------------------------
UltimateStimulsoft.AddDataSet    PROCEDURE(STRING pDataSet,<STRING pConnectionString>)
!---------------------------------------------------------

    CODE

    SELF.qDataSet.DataSet = pDataSet 
    SELF.qDataSet.ConnectionString = CHOOSE(pConnectionString = '',SELF.ConnectionString,pConnectionString)
    ADD(SELF.qDataSet)
       
    
!---------------------------------------------------------
UltimateStimulsoft.SaveToPDF    PROCEDURE(STRING pReportFileName,BYTE pOpenDocument=0) 
!---------------------------------------------------------
   
PDFFileName                         STRING(FILE:MaxFileName) 
DOSDialogHeader                     CSTRING(40)                             
DOSExtParameter                     CSTRING(250)                           
DOSTargetVariable                   CSTRING(256)                           
LocalCount                          LONG

    CODE

    DOSTargetVariable = PDFFileName
        
    DOSDialogHeader = 'Save To PDF'
    DOSExtParameter = 'PDF Files|*.pdf|All Files|*.*'
    IF FILEDIALOG(DOSDialogHeader,DOSTargetVariable,DOSExtParameter,FILE:KeepDIR+FILE:LongName+FILE:Save)
        PDFFileName = DOSTargetVariable 
        IF ~INSTRING('.PDF',UPPER(PDFFileName),1,1)
            PDFFileName = CLIP(PDFFileName) & '.pdf'
        END
        
        SELF.Rpt{'LoadReport("' & CLIP(pReportFileName) & '")'}  
    
        IF SELF.Server   
            LOOP LocalCount = 1 TO RECORDS(SELF.qDataSet)
                GET(SELF.qDataSet,LocalCount)   
                SELF.Rpt{'ConnectToDatabase("' & CLIP(SELF.qDataSet.DataSet) & '","' & CLIP(SELF.qDataSet.ConnectionString) & '")'}
            
            END
        
        END
        SELF.Rpt{'RenderReport(1)'}
        SELF.Rpt{'SaveAs(1,"' & CLIP(PDFFileName) & '",' & pOpenDocument & ')'}
        
    END     
    
    
!---------------------------------------------------------
UltimateStimulsoft.SetLicenseKey        PROCEDURE(STRING pLicenseKey)
!---------------------------------------------------------

    CODE
    
    SELF.Rpt{'SetLicenseKey(' & CLIP(pLicenseKey) & ')'}