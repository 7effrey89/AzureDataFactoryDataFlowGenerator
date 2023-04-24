# Azure Data Factory Data Flow And Pipeline Generator
This repository contains a demo on how to generate a pipeline and dataflow using a C# console application.

## Prerequisite:
- Access to a sql databasse
- Access to a new Azure Data Factory instance connected to either Git or Azure DevOps
- Possibility to execute C# code from your machine. e.g. using Microsoft Vistual Studio Code/ Vistual Studio

## Components in this demo:
A) The neccesary sql scripts creating tables and schemas needed for the demo. 
B) A backup of the Azure Data Factory that was used to add the generated data flows and pipelines. 
C) A C# console application that is used to generate json files for pipeline and dataflow

## Installation Steps:
1) Execute all sql files from the "SQL DB" folder against a Sql Database
2) Restore files from the "DataFactory" folder into a Git repository used by a Data Factory instance.

## The C# Application:
### Meta Data Driven:
The console application uses a csv files as metadata input for generating the pipelines and dataflows. The file used in this code is located: "assets/2JDE.csv"
This file contains details about the:
- Source table
  - Column names, Data type, isPrimaryKey
- Destination table
  - Column names, Data type, isPrimaryKey
- Transformation Logic
   - supports 'DirectMove'
   - calling custom made functions from your Data flow libraries e.g. JulianDateToDate(), toYYYYMM()
   - nesting custom made functions e.g. toYYYYMM(JulianDateToDate())

### Pipeline and Data Flow Templates:
The C# application can generate two different dataflows, and one pipeline. The design of these artifacts are determined by the json templates located in "templates" folder.
These originates from manually made dataflows/pipelines in Data Factory, and has later then been parametrized by replacing the hardcoded configurations with variables that gets their values from the meta data file above.

#### Data flow samples provided by this repo:
Both data flows are designed with Change Data Capture (CDC) in mind.

##### SQL CDC to SQL database
Utiizing the inbuilt CDC functionality in Azure SQL Database to simplify the setup. With this setup you dont have to make custom mechanisms to monitor for deleted rows.
![plot](./Screenshots/SampleOfGeneratedDataFlow1_SQL.png)

##### CDC Flat Files to SQL database
Flattens a nested json file from SAP Success Factor, and implements a mechanism to account for deleted rows before sinking it in a SQL database
![plot](./Screenshots/SampleOfGeneratedDataFlow2_FlatFiles.png)
