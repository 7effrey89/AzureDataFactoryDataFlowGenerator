SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SRC_SCSFCTR].[USER](
	[ADDRESSLINE1] [varchar](4000) NULL,
	[ADDRESSLINE2] [varchar](4000) NULL,
	[ADDRESSLINE3] [varchar](4000) NULL,
	[ASSIGNEEUSERIDOFDOMAINEVENTALERTNAV] [varchar](4000) NULL,
	[ASSIGNMENTUUID] [varchar](4000) NULL,
	[BENCHSTRENGTH] [varchar](4000) NULL,
	[BENCHSTRENGTHNAV] [varchar](4000) NULL,
	[BUSINESSPHONE] [varchar](4000) NULL,
	[BUSINESSSEGMENT] [varchar](4000) NULL,
	[CELLPHONE] [varchar](4000) NULL,
	[CITIZENSHIP] [varchar](4000) NULL,
	[CITY] [varchar](4000) NULL,
	[CODEOFRIGHTTORETURNNAV] [varchar](4000) NULL,
	[COMPETENCY] [varchar](4000) NULL,
	[COMPETENCYRATINGNAV] [varchar](4000) NULL,
	[COSTCENTERMANAGEROFFOCOSTCENTERNAV] [varchar](4000) NULL,
	[COUNTRY] [varchar](4000) NULL,
	[CUST_HEADOFBAOFCUST_BANAV] [varchar](4000) NULL,
	[CUST_HEADOFUNITOFCUST_SUBTEAMNAV] [varchar](4000) NULL,
	[CUST_HEADOFUNITOFCUST_TEAMNAV] [varchar](4000) NULL,
	[CUST_INITIATOROFPOSITIONNAV] [varchar](4000) NULL,
	[CUSTOM01] [varchar](4000) NULL,
	[CUSTOM02] [varchar](4000) NULL,
	[CUSTOM03] [varchar](4000) NULL,
	[CUSTOM04] [varchar](4000) NULL,
	[CUSTOM05] [varchar](4000) NULL,
	[CUSTOM06] [varchar](4000) NULL,
	[CUSTOM07] [varchar](4000) NULL,
	[CUSTOM08] [varchar](4000) NULL,
	[CUSTOM08NAV] [varchar](4000) NULL,
	[CUSTOM09] [varchar](4000) NULL,
	[CUSTOM11] [varchar](4000) NULL,
	[CUSTOM12] [varchar](4000) NULL,
	[CUSTOM13] [varchar](4000) NULL,
	[CUSTOM14] [varchar](4000) NULL,
	[CUSTOM15] [varchar](4000) NULL,
	[CUSTOMMANAGER] [varchar](4000) NULL,
	[CUSTOMREPORTS] [varchar](4000) NULL,
	[DATEOFBIRTH] [varchar](4000) NULL,
	[DATEOFPOSITION] [varchar](4000) NULL,
	[DEFAULTFULLNAME] [varchar](4000) NULL,
	[DEFAULTLOCALE] [varchar](4000) NULL,
	[DELEGATEEOFAUTODELEGATEDETAILNAV] [varchar](4000) NULL,
	[DELEGATOROFAUTODELEGATECONFIGNAV] [varchar](4000) NULL,
	[DEPARTMENT] [varchar](4000) NULL,
	[DIRECTREPORTS] [varchar](4000) NULL,
	[DIVISION] [varchar](4000) NULL,
	[EMAIL] [varchar](4000) NULL,
	[EMPID] [varchar](4000) NULL,
	[EMPINFO] [varchar](4000) NULL,
	[EMPLSTATUS] [varchar](4000) NULL,
	[EMPLOYEE_CLASS] [varchar](4000) NULL,
	[EMPLOYMENTIDENTITYOFDRTMPURGEFREEZENAV] [varchar](4000) NULL,
	[ETHNICITY] [varchar](4000) NULL,
	[ETHNICITYNAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_AAP_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_ABS_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_BENEFPLAN_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_BENEF_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_CARCINO_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_DKTAX_PARENTNAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_DENMARK_STATISTIK_PARENTNAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_DISC_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_EEO_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_EMPCHANGE_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_EMPCONTR_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_EMPFILES_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_FORMS_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_HI_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_HAZARD_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_ID_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_ILLNESS_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_INFILES_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_LEGAL_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_MISCELLANEOUSNAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_OTHER_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_PENSIONPLAN_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_PERM_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_PERSDOC_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_REDDOC_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_TERM_1NAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_CANTINE_DK_PARENTNAV] [varchar](4000) NULL,
	[EXTERNALCODEOFCUST_COMPANYCAR_PARENTNAV] [varchar](4000) NULL,
	[FAX] [varchar](4000) NULL,
	[FIRSTNAME] [varchar](4000) NULL,
	[FUTURELEADER] [varchar](4000) NULL,
	[HEADOFUNITOFFOBUSINESSUNITNAV] [varchar](4000) NULL,
	[HEADOFUNITOFFODEPARTMENTNAV] [varchar](4000) NULL,
	[HEADOFUNITOFFODIVISIONNAV] [varchar](4000) NULL,
	[HIREDATE] [varchar](4000) NULL,
	[HOMEPHONE] [varchar](4000) NULL,
	[HR] [varchar](4000) NULL,
	[HRREPORTS] [varchar](4000) NULL,
	[IMPACTOFLOSS] [varchar](4000) NULL,
	[IMPACTOFLOSSNAV] [varchar](4000) NULL,
	[INCUMBENTOFPOSITIONNAV] [varchar](4000) NULL,
	[ISPRIMARYASSIGNMENT] [varchar](4000) NULL,
	[JOBCODE] [varchar](4000) NULL,
	[KEYPOSITION] [varchar](4000) NULL,
	[LASTMODIFIED] [varchar](4000) NULL,
	[LASTMODIFIEDDATETIME] [varchar](4000) NULL,
	[LASTMODIFIEDWITHTZ] [varchar](4000) NULL,
	[LASTNAME] [varchar](4000) NULL,
	[LASTREVIEWDATE] [varchar](4000) NULL,
	[LEVEL] [varchar](4000) NULL,
	[LOCATION] [varchar](4000) NULL,
	[LOGINMETHOD] [varchar](4000) NULL,
	[MANAGER] [varchar](4000) NULL,
	[MARRIED] [varchar](4000) NULL,
	[MATRIX1LABEL] [varchar](4000) NULL,
	[MATRIX2LABEL] [varchar](4000) NULL,
	[MATRIXMANAGED] [varchar](4000) NULL,
	[MATRIXMANAGER] [varchar](4000) NULL,
	[MATRIXREPORTS] [varchar](4000) NULL,
	[MI] [varchar](4000) NULL,
	[MINORITY] [varchar](4000) NULL,
	[NATIONALITY] [varchar](4000) NULL,
	[NEWTOPOSITION] [varchar](4000) NULL,
	[NICKNAME] [varchar](4000) NULL,
	[OBJECTIVE] [varchar](4000) NULL,
	[ONBOARDINGID] [varchar](4000) NULL,
	[OWNEROFTALENTPOOLNAV] [varchar](4000) NULL,
	[PERFORMANCE] [varchar](4000) NULL,
	[PERSONKEYNAV] [varchar](4000) NULL,
	[POTENTIAL] [varchar](4000) NULL,
	[PROXY] [varchar](4000) NULL,
	[REASONFORLEAVING] [varchar](4000) NULL,
	[REASONFORLEAVINGNAV] [varchar](4000) NULL,
	[REVIEWFREQ] [varchar](4000) NULL,
	[RISKOFLOSS] [varchar](4000) NULL,
	[RISKOFLOSSNAV] [varchar](4000) NULL,
	[SALUTATION] [varchar](4000) NULL,
	[SCILASTMODIFIED] [varchar](4000) NULL,
	[SECONDMANAGER] [varchar](4000) NULL,
	[SECONDREPORTS] [varchar](4000) NULL,
	[SSN] [varchar](4000) NULL,
	[STATE] [varchar](4000) NULL,
	[STATUS] [varchar](4000) NULL,
	[SUFFIX] [varchar](4000) NULL,
	[TALENTPOOL] [varchar](4000) NULL,
	[TARGETIDOFTIMEMANAGEMENTALERTNAV] [varchar](4000) NULL,
	[TEAMMEMBERSSIZE] [varchar](4000) NULL,
	[TIMEZONE] [varchar](4000) NULL,
	[TITLE] [varchar](4000) NULL,
	[TOTALTEAMSIZE] [varchar](4000) NULL,
	[USERID] [varchar](4000) NULL,
	[USERIDOFACCRUALCALCULATIONBASENAV] [varchar](4000) NULL,
	[USERIDOFBUDGETGROUPNAV] [varchar](4000) NULL,
	[USERIDOFEMPLOYEEPAYROLLRUNRESULTSNAV] [varchar](4000) NULL,
	[USERIDOFEMPLOYEETIMEGROUPNAV] [varchar](4000) NULL,
	[USERIDOFEMPLOYEETIMENAV] [varchar](4000) NULL,
	[USERIDOFPOSITIONRIGHTTORETURNNAV] [varchar](4000) NULL,
	[USERIDOFTEMPORARYTIMEINFORMATIONNAV] [varchar](4000) NULL,
	[USERIDOFTIMEACCOUNTNAV] [varchar](4000) NULL,
	[USERIDOFTIMEACCOUNTSNAPSHOTNAV] [varchar](4000) NULL,
	[USERIDOFWORKSCHEDULENAV] [varchar](4000) NULL,
	[USERPERMISSIONSNAV] [varchar](4000) NULL,
	[USERSYSIDOFWORKORDERNAV] [varchar](4000) NULL,
	[USERNAME] [varchar](4000) NULL,
	[USERSSYSIDOFHIREDATECHANGENAV] [varchar](4000) NULL,
	[USERSSYSIDOFSECONDARYASSIGNMENTSITEMNAV] [varchar](4000) NULL,
	[WORKORDEROWNERIDOFWORKORDERNAV] [varchar](4000) NULL,
	[WORKEROFPAYMENTINFORMATIONV3NAV] [varchar](4000) NULL,
	[ZIPCODE] [varchar](4000) NULL,
	[SRC_DELETED_FLG] [varchar](1) NULL,
	[LAST_UPDATED_TS] [datetime] NULL
) ON [PRIMARY]
GO
