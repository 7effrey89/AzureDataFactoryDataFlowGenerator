# Azure Data Factory Data Flow And Pipeline Generator
This repository contains a demo on how to generate a pipeline and dataflow using a C# console application.

Prerequisite:
- Access to a sql databasse
- Access to a new Azure Data Factory instance connected to either Git or Azure DevOps
- Possibility to execute C# code from your machine. e.g. using Microsoft Vistual Studio Code/ Vistual Studio

Components in this demo:
A) The neccesary sql scripts creating tables and schemas needed for the demo. 
B) A backup of the Azure Data Factory that was used to add the generated data flows and pipelines. 
C) A C# console application that is used to generate json files for pipeline and dataflow

Installation Steps:
1) Execute all sql files from the "SQL DB" folder against a Sql Database
2) Restore files from the "DataFactory" folder into a Git repository used by a Data Factory instance.

The C# Application:
The console application uses a csv files as metadata input for generating the pipelines and dataflows. The file used in this code is located: "assets/2JDE.csv"
This file contains details about the:
- Source table
  -- Column names, Data type, isPrimaryKey
- Destination table
  -- Column names, Data type, isPrimaryKey
- Transformation Logic (supports 'DirectMove' or calling custom made functions from the Data flow libraries such as JulianDateToDate(), toYYYYMM(), and nested functions e.g. toYYYYMM(JulianDateToDate()) )

