namespace GlobalPortal.Api.Demo.Models
{
    /// <summary>
    /// Model used to mark as received an appointment cancellation request or an appointment request or a patient communication .
    /// </summary>
    public class MarkAsReceivedModel
    {
        /// <summary>
        /// Mark as received an appointment cancellation request or an appointment request or a patient communication with your ID.
        /// </summary>
        public string MarkAsReceivedID { get; set; }

        /// <summary>
        /// Object type is a patient communication or an appointment request or an appointment cancellation request.
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Result message.
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// Success result.
        /// </summary>
        public bool Success { get; set; }
    }
}
