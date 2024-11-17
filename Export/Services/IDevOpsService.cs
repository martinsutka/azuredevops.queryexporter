using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace Export.Services
{
    /// <summary>
    /// Interface which defines Azure DevOps service functionality.
    /// </summary>
    public interface IDevOpsService
    {
        #region [ Properties ]

        /// <summary>
        /// Name of the query.
        /// </summary>
        string QueryName
        {
            get;
        }


        /// <summary>
        /// List of query's work item relations.
        /// </summary>
        List<WorkItemLink> Relations
        {
            get;
        }


        /// <summary>
        /// Personal access token.
        /// </summary>
        string Pat
        {
            get;
        }


        /// <summary>
        /// Project name.
        /// </summary>
        string Project
        {
            get;
        }


        /// <summary>
        /// Url of the collection.
        /// </summary>
        string Url
        {
            get;
        }

        #endregion


        #region [ Methods ]

        /// <summary>
        /// Sets the personal access token.
        /// </summary>
        /// <param name="pat">Personal access token.</param>
        /// <returns>Returns <see cref="IDevOpsService"/>.</returns>
        IDevOpsService SetPat(string pat);


        /// <summary>
        /// Sets the project name.
        /// </summary>
        /// <param name="project">Project name.</param>
        /// <returns>Returns <see cref="IDevOpsService"/>.</returns>
        IDevOpsService SetProject(string project);


        /// <summary>
        /// Sets the url of the collection.
        /// </summary>
        /// <param name="url">Url of the collection.</param>
        /// <returns>Returns <see cref="IDevOpsService"/>.</returns>
        IDevOpsService SetUrl(string url);


        /// <summary>
        /// Gets the results of the query given the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Query Id.</param>
        /// <returns>Returns list of work item ids.</returns>
        Task<List<int>> QueryByIdAsync(Guid id);


        /// <summary>
        /// Returns a list of work items.
        /// </summary>
        /// <param name="ids">List of work item ids.</param>
        /// <returns>Returns list of <see cref="WorkItem"/>.</returns>
        Task<List<WorkItem>> GetWorkItemsAsync(List<int> ids);


        /// <summary>
        /// Returns a list of work item comments.
        /// </summary>
        /// <param name="ids">List of work item ids.</param>
        /// <returns>Task.</returns>
        Task<Dictionary<int, List<WorkItemComment>>> GetCommentsAsync(List<int> ids);


        /// <summary>
        /// Downloadsall the attachemnts.
        /// </summary>
        /// <param name="wits">List of work items.</param>
        /// <param name="output">Output directory.</param>
        /// <returns>List of streams.</returns>
        IEnumerable<(Task<Stream> Content, Models.Attachment Attachment)> DownloadAttachmentsAsync(List<Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem> wits);

        #endregion
    }
}
