using System;
using System.Dynamic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MigrationTools.DataContracts.Pipelines
{
    [ApiPath("distributedtask/taskgroups")]
    [ApiName("Task Groups")]
    public partial class TaskGroup : RestApiDefinition
    {
        public override string ToString()
        {
            return $"TaskGroup Information:\n" +
                   $"  TaskGroupId: {TaskGroupId ?? "N/A"}\n" +
                   $"  FriendlyName: {FriendlyName ?? "N/A"}\n" +
                   $"  Description: {Description ?? "N/A"}\n" +
                   $"  CreatedBy: {CreatedBy?.DisplayName ?? "N/A"}\n" +
                   $"  CreatedOn: {CreatedOn}\n" +
                   $"  ModifiedBy: {ModifiedBy?.DisplayName ?? "N/A"}\n" +
                   $"  ModifiedOn: {ModifiedOn}\n" +
                   $"  Version: {Version?.Major ?? 0}.{Version?.Minor ?? 0}.{Version?.Patch ?? 0}\n" +
                   $"  IconUrl: {IconUrl ?? "N/A"}\n" +
                   $"  Category: {Category ?? "N/A"}\n" +
                   $"  DefinitionType: {DefinitionType ?? "N/A"}\n" +
                   $"  Author: {Author ?? "N/A"}\n" +
                   $"  Comment: {Comment ?? "N/A"}\n" +

                   $"  Owner: {Owner ?? "N/A"}\n" +
                   $"  ContentsUploaded: {ContentsUploaded}\n" +
                   $"  PackageType: {PackageType ?? "N/A"}\n" +
                   $"  PackageLocation: {PackageLocation ?? "N/A"}\n" +
                   $"  SourceLocation: {SourceLocation ?? "N/A"}\n" +
                   $"  MinimumAgentVersion: {MinimumAgentVersion ?? "N/A"}\n" +
                   $"  HelpMarkDown: {HelpMarkDown ?? "N/A"}\n" +
                   $"  Preview: {Preview}\n" +
                   $"  ParentDefinitionId: {ParentDefinitionId ?? "N/A"}\n" +
                   $"  TaskGroupRevision: {TaskGroupRevision}\n" +

                   $"  Revision: {Revision}\n" +
                   $"  SourceDef: {string.Join(", ", SourceDefinitions) ?? "N/A"}\n" +
                   $"  Groups: {string.Join(", ", Groups) ?? "N/A"}\n" +
                   $"  InstanceNameFormat: {InstanceNameFormat ?? "N/A"}\n";
        }


        public string ParentDefinitionId { get; set; }
        public string TaskGroupId { get; set; }
        public long ParentDefinitionRevision { get; set; }
        public long TaskGroupRevision { get; set; }
        public bool Preview { get; set; }

        protected ILogger Log { get; }

        public TaskElement[] Tasks { get; set; }

        public string[] RunsOn { get; set; }

        public long Revision { get; set; }

        public EdBy CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public EdBy ModifiedBy { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public Version Version { get; set; }

        public string IconUrl { get; set; }

        public string FriendlyName { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string DefinitionType { get; set; }

        public string Author { get; set; }

        public object[] Demands { get; set; }

        public object[] Groups { get; set; }

        public Input[] Inputs { get; set; }

        public object[] Satisfies { get; set; }

        public object[] SourceDefinitions { get; set; }

        public object[] DataSourceBindings { get; set; }

        public string InstanceNameFormat { get; set; }

        public Execution PreJobExecution { get; set; }

        public Execution Execution { get; set; }

        public Execution PostJobExecution { get; set; }

        public string Comment { get; set; }

        public string[] Visibility { get; set; }

        public string? Owner { get; set; }

        public bool? ContentsUploaded { get; set; }

        public string PackageType { get; set; }

        public string PackageLocation { get; set; }

        public string SourceLocation { get; set; }

        public string MinimumAgentVersion { get; set; }

        public string HelpMarkDown { get; set; }

        public override bool HasTaskGroups()
        {
            Log.LogError("we currently not support taskgroup nesting.");
            return false;
        }

        public override bool HasVariableGroups()
        {
            Log.LogError("we currently not support variablegroup nesting.");
            return false;
        }

        public override void ResetObject()
        {
            SetSourceId(Id);
            Revision = 0;
        }
    }

    public partial class EdBy
    {
        public string DisplayName { get; set; }

        public string Id { get; set; }

        public string UniqueName { get; set; }
    }

    public partial class Execution
    {
    }

    public partial class Input
    {
        public object[] Aliases { get; set; }

        public Execution Options { get; set; }

        public Properties Properties { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string DefaultValue { get; set; }

        public bool InputRequired { get; set; }

        public string Type { get; set; }

        public string HelpMarkDown { get; set; }

        public string GroupName { get; set; }
    }

    public partial class Properties
    {
        public string EditableOptions { get; set; }
    }

    public partial class TaskElement
    {
        public Execution Environment { get; set; }

        public string DisplayName { get; set; }

        public bool AlwaysRun { get; set; }

        public bool ContinueOnError { get; set; }

        public string? Condition { get; set; }

        public bool Enabled { get; set; }

        public long TimeoutInMinutes { get; set; }

        public ExpandoObject Inputs { get; set; }

        public TaskTask Task { get; set; }
        public override string ToString()
{
    return $"DisplayName: {DisplayName}\nAlwaysRun: {AlwaysRun}\nContinueOnError: {ContinueOnError}\nCondition: {Condition}\nEnabled: {Enabled}\nTimeoutInMinutes: {TimeoutInMinutes}\nInputs: {Inputs}\nTask: {Task}\n";
}

    }

    public partial class TaskTask
    {
        public string Id { get; set; }

        public string VersionSpec { get; set; }

        public string DefinitionType { get; set; }

        public override string ToString()
{
    return $"Id: {Id}\nVersionSpec: {VersionSpec}\nDefinitionType: {DefinitionType}\n";
}


    }

    public partial class Version
    {
        public long Major { get; set; }

        public long Minor { get; set; }

        public long Patch { get; set; }

        public bool IsTest { get; set; } = false;
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}