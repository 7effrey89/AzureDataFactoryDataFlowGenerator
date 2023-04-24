// See https://aka.ms/new-console-template for more information
using ChoETL;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data;
using System.Formats.Asn1;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        //Husk at overvej checkpoint for hver pipleine. ny hver gang?

        // This will get the current WORKING directory(i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        // Template
        //string mappingTableFilePath = projectDirectory + @"/assets/Sap_SuccessFactor_User.csv";
        //string dataflowTemplate = @"/templates/DataFlow/template-SapSuccessFactor.txt"; 
        //string pipelineTemplate = @"/templates/Pipelines/template_SapSuccessFactor_Pipeline.txt"; 

        //string mappingTableFilePath = projectDirectory + @"/assets/JDEE1_F4101.csv"; 
        //string dataflowTemplate = @"/templates/DataFlow/template-DataFlow-JDEE1.txt"; 
        //string pipelineTemplate = @"/templates/Pipelines/template_JDEE1_Pipeline.txt";


        string mappingTableFilePath = projectDirectory + @"/assets/2JDE.csv"; //CSV file contains for two JDEE1 tables (F4101 and F4104).
        string dataflowTemplate = @"/templates/DataFlow/template-DataFlow-JDEE1.txt";
        string pipelineTemplate = @"/templates/Pipelines/template_JDEE1_Pipeline.txt";

        // Source file
        DataTable dtMain = ConvertCSVtoDataTable(mappingTableFilePath);

        List<DataTable> result = dtMain.AsEnumerable()
           .GroupBy(row => row.Field<string>("SourceTableName"))
           .Select(g => g.CopyToDataTable())
           .ToList();

        //foreach loop
        foreach(DataTable dt in result)
        {
            //parameters
            //SourceSchema	SourceTableName	SourceColumnName	SourceDataType	TransformationLogic	DestinationSchema	DestinationTable	DestinationColumnName	DestinationDataType

            string sourceSchema = dt.Rows[0]["SourceSchema"].ToString();
            string sourceTable = dt.Rows[0]["SourceTableName"].ToString();

            string destinationSchema = dt.Rows[0]["destinationSchema"].ToString();
            string destinationTable = dt.Rows[0]["DestinationTableName"].ToString();

            //Console.WriteLine("FIRST ROW, DOSAGE: {0}", dt.Rows[0]["SourceColumnName"]);

            //Creating schema definition for source table
            int itemCount = dt.Rows.Count;

            string schemaProjectColumnLine = "\n";

            string DerColumnLine = "\n";  //"name = toTrim(name),\",\r\n                \"          column1 = julianDate(date)";
            string targetProjectColumnLine = "\n";
            string destinationColumnMapping = "\n";
            string jsonColumnMapping = "\n";
            string jsonFlatColumnMapping = "\n";
            string pkeys = "";
            string pkeysSelectActivity = "\n";
            string pkeysIfExistsActivity = "\n";
            string ConditionalSplitPkeys = "\n";
            //name = toTrim(name),",
            //    "          column1 = julianDate(date)
            string jsonNewLine = ",\",\n";
            string jsonNewLineEnd = "\",\n";
            for (int i = 0; i <= itemCount - 1; i++)
            { // print numbers from 1 to 5
                string SourceColumnName = dt.Rows[i]["SourceColumnName"].ToString();
                string SourceColumnPrimaryKey = dt.Rows[i]["SourceColumnPrimaryKey"].ToString();
                string SourceDataType = dt.Rows[i]["SourceDataType"].ToString().ToLower();
                string TransformationLogic = dt.Rows[i]["TransformationLogic"].ToString();
                string destinationColumnName = dt.Rows[i]["destinationColumnName"].ToString();
                string DestinationColumnPrimaryKey = dt.Rows[i]["DestinationColumnPrimaryKey"].ToString();
                string DestinationDataType = dt.Rows[i]["DestinationDataType"].ToString().ToLower();

                //if ("MANAGER"== dt.Rows[i]["destinationColumnName"].ToString())
                //{
                //    "ff".ToString();
                //}
                SourceDataType = replaceDataType(SourceDataType, "char", "string");
                SourceDataType = replaceDataType(SourceDataType, "float", "double");
                SourceDataType = replaceDataType(SourceDataType, "numeric", "decimal");
                SourceDataType = replaceDataType(SourceDataType, "number", "decimal");
                SourceDataType = replaceDataType(SourceDataType, "datetime", "date");
                SourceDataType = replaceDataType(SourceDataType, "int", "integer");

                DestinationDataType = replaceDataType(DestinationDataType, "char", "string");
                DestinationDataType = replaceDataType(DestinationDataType, "float", "double");
                DestinationDataType = replaceDataType(DestinationDataType, "numeric", "decimal");
                DestinationDataType = replaceDataType(DestinationDataType, "number", "decimal");
                DestinationDataType = replaceDataType(DestinationDataType, "datetime", "date");
                DestinationDataType = replaceDataType(DestinationDataType, "int", "integer");

                //if (SourceDataType.Contains("float"))
                //{
                //    SourceDataType = "double";
                //}
                //if (SourceDataType.Contains("numeric"))
                //{
                //    SourceDataType = SourceDataType.Replace("numeric", "decimal");
                //}
                //if (SourceDataType.Contains("datetime"))
                //{
                //    SourceDataType = "date";
                //}
                //if (SourceDataType.Contains("int"))
                //{
                //    SourceDataType = "integer";
                //}
                //if (SourceDataType.Contains("number"))
                //{
                //    SourceDataType = DestinationDataType.Replace("number", "decimal");
                //}

                //if (DestinationDataType.Contains("char"))
                //{
                //    DestinationDataType = "string";
                //}
                //if (DestinationDataType.Contains("float"))
                //{
                //    DestinationDataType = "double";
                //}
                //if (DestinationDataType.Contains("numeric"))
                //{
                //    DestinationDataType = DestinationDataType.Replace("numeric", "decimal");
                //}
                //if (DestinationDataType.Contains("number"))
                //{
                //    DestinationDataType = DestinationDataType.Replace("number", "decimal");
                //}
                //if (DestinationDataType.Contains("datetime"))
                //{
                //    DestinationDataType = "timestamp";
                //}
                //if (DestinationDataType.Contains("int"))
                //{
                //    DestinationDataType = "integer";
                //}
                //det virker til at datetime måske skal laves til date

                //if (TransformationLogic=="Direct")
                int transformationCounts = TransformationLogic.Count(f => f == '(');

                int index = 0;
                string end = "";
                string tranformationStatement = SourceColumnName;

                if (transformationCounts == 0)
                {


                }
                else
                {
                    index = TransformationLogic.LastIndexOf("(") + 1;
                    end = string.Concat(Enumerable.Repeat(")", transformationCounts));
                    tranformationStatement = TransformationLogic.Substring(0, index) + SourceColumnName + end;
                }

                //SQL Source Schema Column Import
                if (!schemaProjectColumnLine.Contains("          " + SourceColumnName + " as " + SourceDataType))
                {
                    schemaProjectColumnLine = schemaProjectColumnLine + "                \"          " + SourceColumnName + " as " + SourceDataType + jsonNewLine;
                }
                //SQL Sink Schema Column Import
                if (!targetProjectColumnLine.Contains("          " + destinationColumnName + " as " + DestinationDataType))
                {
                    targetProjectColumnLine = targetProjectColumnLine + "                \"          " + destinationColumnName + " as " + DestinationDataType + jsonNewLine;
                }

                //JSON Source Schema Column Import
                if (!jsonColumnMapping.Contains("          " + SourceColumnName + " as " + SourceDataType))
                {
                    jsonColumnMapping = jsonColumnMapping + "                \"          " + SourceColumnName + " as " + SourceDataType + jsonNewLine;
                }

                //Column Names for Flattening transformation
                jsonFlatColumnMapping = jsonFlatColumnMapping + "                \"          " + destinationColumnName + " = d.results." + SourceColumnName + jsonNewLine;

                //Column Names for DER transformation
                DerColumnLine = DerColumnLine + "                \"          " + destinationColumnName + " = " + tranformationStatement + jsonNewLine;

                //SQL Sink Column Mapping
                destinationColumnMapping = destinationColumnMapping + "                \"          " + destinationColumnName + jsonNewLine;

                //SQL Sink Primary Key List
                if (DestinationColumnPrimaryKey.ToLower().Equals("y"))
                {
                    pkeys = pkeys + "'" + destinationColumnName + "',";
                    pkeysSelectActivity = pkeysSelectActivity + "                \"          " + destinationColumnName + jsonNewLine;
                    pkeysIfExistsActivity = pkeysIfExistsActivity + "                \"          flatten1@" + destinationColumnName + "==select1@" + destinationColumnName + " && " + jsonNewLine;
                    ConditionalSplitPkeys = ConditionalSplitPkeys + "                \"          isNull(flatten1@" + destinationColumnName + ") && !isNull(select1@" + destinationColumnName + ") && " + jsonNewLine;

                }
            }

            //fixing the end of the iterations
            schemaProjectColumnLine = EndOfIterationFix(schemaProjectColumnLine, jsonNewLine, jsonNewLineEnd);
            DerColumnLine = EndOfIterationFix(DerColumnLine, jsonNewLine, jsonNewLineEnd);
            targetProjectColumnLine = EndOfIterationFix(targetProjectColumnLine, jsonNewLine, jsonNewLineEnd);
            destinationColumnMapping = EndOfIterationFix(destinationColumnMapping, jsonNewLine, jsonNewLineEnd);
            jsonFlatColumnMapping = EndOfIterationFix(jsonFlatColumnMapping, jsonNewLine, jsonNewLineEnd);
            jsonColumnMapping = EndOfIterationFix(jsonColumnMapping, jsonNewLine, jsonNewLineEnd);

            if (!pkeys.Equals(""))
            {
                pkeys = pkeys.Substring(0, pkeys.Length - "',".Length) + "'";
                pkeysSelectActivity = EndOfIterationFix(pkeysSelectActivity, jsonNewLine, jsonNewLineEnd); 
                pkeysIfExistsActivity = pkeysIfExistsActivity.Substring(0, pkeysIfExistsActivity.Length - jsonNewLine.Length - " && ".Length) + "," + jsonNewLineEnd;
                ConditionalSplitPkeys = ConditionalSplitPkeys.Substring(0, ConditionalSplitPkeys.Length - jsonNewLine.Length - " && ".Length) + "," + jsonNewLineEnd;
            }


            Dictionary<string, string> replacements = new Dictionary<string, string>(){
                {"{sourceSchema}", sourceSchema},
                {"{sourceTable}", sourceTable},
                {"{destinationSchema}", destinationSchema},
                {"{destinationTable}", destinationTable},
                {"{COLUMN as DATATYPE}", schemaProjectColumnLine},
                {"{DerColumnList}", DerColumnLine},
                {"{targetProjectColumnLine}", targetProjectColumnLine},
                {"{destinationColumnMapping}", destinationColumnMapping},
                {"{jsonColumnMapping}", jsonColumnMapping},
                {"{jsonFlatColumnMapping}", jsonFlatColumnMapping},
                {"{pkeysSelectActivity}", pkeysSelectActivity},
                {"{pkeysIfExistsActivity}", pkeysIfExistsActivity},
                {"{pkeys}", pkeys},
            };

            CreateOutPut(projectDirectory, dataflowTemplate, destinationSchema, destinationTable, replacements, "DataFlow");

            CreateOutPut(projectDirectory, pipelineTemplate, destinationSchema, destinationTable, replacements, "Pipeline");

        }

    }

    private static string replaceDataType(string SourceDataType, string dataTypeToReplace, string dataTypeToBe)
    {
        if (SourceDataType.Contains(dataTypeToReplace))
        {

            if (SourceDataType.Contains("number") || SourceDataType.Contains("numeric"))
            {
                SourceDataType = SourceDataType.Replace(dataTypeToReplace, dataTypeToBe);

            }
            else
            {
                SourceDataType = dataTypeToBe;
            }

            
        }
        return SourceDataType;
    }

    private static string EndOfIterationFix(string schemaProjectColumnLine, string jsonNewLine, string jsonNewLineEnd)
    {
        schemaProjectColumnLine = schemaProjectColumnLine.Substring(0, schemaProjectColumnLine.Length - jsonNewLine.Length) + jsonNewLineEnd;
        return schemaProjectColumnLine;
    }

    private static void CreateOutPut(string projectDirectory, string TemplatePath, string destinationSchema, string destinationTable, Dictionary<string, string> replacements, string artifactType)
    {
        //Filling the pipeline template
        string template = File.ReadAllText(projectDirectory + "/" + TemplatePath);

        foreach (string key in replacements.Keys)
        {
            template = template.Replace(key, replacements[key]);
        }
        Console.WriteLine(template); // outputs "This is a car that is red."

        //output folder
        string outputPath = @"output/"+ artifactType + "/"; // Your code goes here

        System.IO.Directory.CreateDirectory(outputPath);

        //create output file
        _ = WriteToFile(outputPath + destinationTable + ".json", template);
    }

    public void createOutput()
    {

    }
    public static async Task WriteToFile(string filePath, string fileContent)
    {
        File.WriteAllText(filePath, fileContent);
    }
    private static DataTable ConvertCSVtoDataTable(string strFilePath)
    {
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            string[] headers = sr.ReadLine().Split(';');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(';');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }

        }

        return dt;
    }

    private static void WriteToDb(DataTable dt)
    {
        string connectionString =
            "Data Source=localhost;" +
            "Initial Catalog=Northwind;" +
            "Integrated Security=SSPI;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("spInsertTest", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@policyID", SqlDbType.Int).Value = 12;
                cmd.Parameters.Add("@statecode", SqlDbType.VarChar).Value = "blagh2";
                cmd.Parameters.Add("@county", SqlDbType.VarChar).Value = "blagh3";

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
