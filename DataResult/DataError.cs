namespace DataResult
{
    /// <summary>
    ///     Class to be used as error in DataResult.
    /// </summary>
    public class DataError
    {
        /// <summary>
        ///     Gets or sets the code to identify the kind of error.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description of the error.
        /// </summary>
        public string Description { get; set; }
    }
}