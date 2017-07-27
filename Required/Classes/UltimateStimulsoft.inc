!-----------------------------------------------------------------------
!Purpose        :
!Usage          :
!Created        :
!Updates        :
!Assumptions    :
!Known Bugs     :
!Future Features:
 
qDataSetType                    QUEUE,PRE(qDataSet),TYPE 
DataSet                             STRING(100)
ConnectionString                    STRING(300)

                                END
             
             
UltimateStimulsoft              CLASS,TYPE,MODULE('UltimateStimulsoft.CLW'),LINK('UltimateStimulsoft.CLW')
 
!
!Properties
!----------
InDebug                             BYTE
     
DataSet                             STRING(100)

qDataSet                            &qDataSetType


Server                              STRING(100)
Catalog                             STRING(100)
TrustedConnection                   STRING(10)
UserID                              STRING(100)
Password                            STRING(100)

Rpt                                 LONG 

ConnectionString                    STRING(600)

!
!Methods
!-------
Construct                           PROCEDURE()
Destruct                            PROCEDURE()
Init                                PROCEDURE(STRING pLicenseKey)
Kill                                PROCEDURE()
RaiseError                          PROCEDURE(STRING pErrorMsg)   
                      
AddVariable                         PROCEDURE(STRING pVariableName,STRING pVariableType,STRING pValue)
AssignVariable                      PROCEDURE(STRING pVariableName,STRING pValue)
ShowReport                          PROCEDURE(STRING pReportFileName)
ShowDesigner                        PROCEDURE(<STRING pReportFileName>)
                                       
ClearDataSetCollection              PROCEDURE()
AddDataSet                          PROCEDURE(STRING pDataSet,<STRING pConnectionString>)
  
SaveToPDF                           PROCEDURE(STRING pReportFileName,BYTE pOpenDocument=0)

SetLicenseKey                       PROCEDURE(STRING pLicenseKey)

 
                                END



