using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace Export
{
    /// <summary>
    /// Azure DevOps http client wrapper.
    /// </summary>
    public class DevOpsClient : IDisposable
    {
        #region [ Methods ]

        /// <summary>
        /// Retrieves an <see cref="WorkItemTrackingHttpClient"/> client.
        /// </summary>
        /// <returns><see cref="WorkItemTrackingHttpClient"/>.</returns>
        public WorkItemTrackingHttpClient Get()
        {
            return this.client;
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. 
        /// </summary>
        public void Dispose()
        {
            this.client.Dispose();
            this.connection.Dispose();

            this.client = null;
            this.connection = null;
        }

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pat">Personal access token.</param>
        /// <param name="url">Url of the collection.</param>
        public DevOpsClient(string pat, string url)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(pat);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(url);

            this.connection = new VssConnection(new Uri(url), new VssBasicCredential(pat, string.Empty));
            this.client = this.connection.GetClient<WorkItemTrackingHttpClient>();
        }

        #endregion


        #region [ Fields ]

        private VssConnection connection;
        private WorkItemTrackingHttpClient client;

        #endregion
    }
}
