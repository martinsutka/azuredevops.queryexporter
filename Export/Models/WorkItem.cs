using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace Export.Models
{
    /// <summary>
    /// Describes a work item.
    /// </summary>
    public partial class WorkItem : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem
    {
        #region [ Properties ]

        /// <summary>
        /// Path in the query.
        /// </summary>
        public string Path
        {
            get;
            set;
        }


        /// <summary>
        /// The level of the work item in the query.
        /// </summary>
        public int Level
        {
            get => this.Path?.Split("/").Length ?? 0;
        }


        /// <summary>
        /// Title.
        /// </summary>
        public string Title
        {
            get => (string)this.Fields.GetValueOrDefault(Models.Fields.Title, string.Empty);
        }


        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get => (string)this.Fields.GetValueOrDefault(Models.Fields.Description, string.Empty);
        }


        /// <summary>
        /// Tags.
        /// </summary>
        public string[] Tags
        {
            get => ((string)this.Fields.GetValueOrDefault(Models.Fields.Tags, string.Empty)).Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
        }


        /// <summary>
        /// Node name or area.
        /// </summary>
        public string NodeName
        {
            get => (string)this.Fields.GetValueOrDefault(Models.Fields.NodeName, string.Empty);
        }
        
        
        /// <summary>
        /// State.
        /// </summary>
        public string State
        {
            get => (string)this.Fields.GetValueOrDefault(Models.Fields.State, string.Empty);
        }


        /// <summary>
        /// Itteration.
        /// </summary>
        public string IterationPath
        {
            get => string.Join(@"\", ((string)this.Fields.GetValueOrDefault(Models.Fields.IterationPath, string.Empty)).Split(@"\").Skip(1).Select(i => i));
        }


        /// <summary>
        /// Comments count.
        /// </summary>
        public long CommentsCount
        {
            get => (long)this.Fields.GetValueOrDefault(Models.Fields.CommentCount, 0);
        }


        /// <summary>
        /// Name of the work item folder.
        /// </summary>
        public string Folder
        {
            get => $"{this.Id}_{Regex.Replace(Regex.Replace(ToAccentInsensitive(this.Title).ToLower(), "[^a-zA-Z0-9]", "-"), "-{2,}", "-")}";
        }


        /// <summary>
        /// List of attachment relations.
        /// </summary>
        public List<Models.Attachment> Attachments
        {
            get;
            private set;
        }

        #endregion


        #region [ Methods : Private ]

        /// <summary>
        /// Gets accent insensitive string.
        /// </summary>
        /// <param name="value">String to be proccesed.</param>
        /// <returns>Accent insensitive string.</returns>
        private static string ToAccentInsensitive(string value)
        {
            string normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Source work item.</param>
        public WorkItem(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem source)
        {
            this.Id = source.Id;
            this.Fields = source.Fields;
            this.Relations = source.Relations;
            this.Url = source.Url;
            this.Attachments = source.Relations.Where(r => r.Rel == "AttachedFile").Select(a => new Models.Attachment(a)).ToList();
        }

        #endregion
    }
}
