namespace DataResult
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     An object that is used as a return type. Errors can be added to the object, thus giving a richer response. <see cref="DataResult{TEntity}"/> can be used to return entities.
    /// </summary>
    public class DataResult
    {
        /// <summary>
        ///     Returns a new <see cref="DataResult"/> which is succeeded.
        /// </summary>
        public static readonly DataResult Success = new DataResult
        {
            Succeeded = true,
        };

        // Field gets used by inherited class.
#pragma warning disable SA1401 // Fields should be private
        public ICollection<DataError> Errors = new List<DataError>();
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        ///     Gets or sets a value indicating whether the <see cref="DataResult"/> is succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        ///     Adds a <see cref="DataError"/> to the new <see cref="DataResult"/> object.
        /// </summary>
        /// <param name="code">
        ///     The error code of the <see cref="DataError"/> object.
        /// </param>
        /// <param name="description">
        ///     The error description of the <see cref="DataError"/> object.
        /// </param>
        /// <returns>
        ///     A new <see cref="DataResult"/> object with the <see cref="DataError"/>.
        /// </returns>
        public static DataResult WithError(string code, string description)
        {
            return new DataResult
            {
                Errors = new List<DataError>
                {
                    new DataError
                    {
                        Code = code,
                        Description = description,
                    },
                },
                Succeeded = false,
            };
        }

        /// <summary>
        ///     Adds a <see cref="DataError"/> to the new <see cref="DataResult"/> object.
        /// </summary>
        /// <param name="error">
        ///     The <see cref="DataError"/> object to add to the <see cref="DataResult"/> object.
        /// </param>
        /// <returns>
        ///     A new <see cref="DataResult"/> object with the <see cref="DataError"/>.
        /// </returns>
        public static DataResult WithError(DataError error)
        {
            return new DataResult
            {
                Errors = new List<DataError>
                {
                    error,
                },
                Succeeded = false,
            };
        }

        /// <summary>
        ///     Adds a collection of <see cref="DataError"/> to the new <see cref="DataResult"/> object.
        /// </summary>
        /// <param name="errors">
        ///     The collection of <see cref="DataError"/> to add to the <see cref="DataResult"/> object.
        /// </param>
        /// <returns>
        ///     A new <see cref="DataResult"/> object with the collection of <see cref="DataError"/>.
        /// </returns>
        public static DataResult WithError(ICollection<DataError> errors)
        {
            return new DataResult
            {
                Errors = errors,
                Succeeded = false,
            };
        }

        /// <summary>
        ///     Adds a new <see cref="DataError"/> to a existing <see cref="DataResult"/>.
        /// </summary>
        /// <param name="code">
        ///     The error code of the <see cref="DataError"/> object.
        /// </param>
        /// <param name="description">
        ///     The error description of the <see cref="DataError"/> object.
        /// </param>
        public void AddError(string code, string description)
        {
            this.Succeeded = false;

            this.Errors.Add(new DataError
            {
                Code = code,
                Description = description,
            });
        }

        /// <summary>
        ///     Gets the collection of <see cref="DataError"/> a <see cref="DataResult"/> object.
        /// </summary>
        /// <returns>
        ///     The collection of <see cref="DataError"/> of the <see cref="DataResult"/> object.
        /// </returns>
        public ICollection<DataError> GetErrors()
        {
            return this.Errors;
        }

        /// <summary>
        ///     Checks if a <see cref="DataResult"/> object has a <see cref="DataError"/> with the given error code.
        /// </summary>
        /// <param name="code">
        ///     The error code on which to check the <see cref="DataError"/>.
        /// </param>
        /// <returns>
        ///     True if there is a <see cref="DataError"/> object with the given error code in the <see cref="DataResult"/>.
        /// </returns>
        public bool HasError(string code)
        {
            return this.Errors.Any(error => error.Code.Equals(code));
        }
    }
}