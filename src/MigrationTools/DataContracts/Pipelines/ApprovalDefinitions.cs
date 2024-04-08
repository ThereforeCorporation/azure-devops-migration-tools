using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.VisualStudio.Services.Common;
using Newtonsoft.Json;

namespace MigrationTools.DataContracts.Pipelines
{
    [ApiPath("release/approvals")]
    [ApiName("Approval Definition")]
    public partial class ApprovalDefinition : RestApiDefinition
    {
        public override bool HasTaskGroups()
        {
            throw new NotImplementedException();
        }

        public override bool HasVariableGroups()
        {
            throw new NotImplementedException();
        }

        public override void ResetObject()
        {
            throw new NotImplementedException();
        }
    }

}