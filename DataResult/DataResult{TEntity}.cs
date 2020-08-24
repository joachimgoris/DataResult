namespace DataResult
{
    using System.Collections.Generic;

    /// <summary>
    ///     An object that is used as a return type. Errors and entities can be added to the object, thus giving a richer response.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The type of entity to return in the <see cref="DataResult{TEntity}"/>.
    /// </typeparam>
    public class DataResult<TEntity> : DataResult
    {
        /// <summary>
        ///     Gets or sets the entity that gets added to the <see cref="DataResult{TEntity}"/>.
        /// </summary>
        public TEntity Entity { get; set; }

        /// <summary>
        ///     Returns a new <see cref="DataResult{TEntity}"/> which is succeeded.
        /// </summary>
        /// <param name="entity">
        ///     The entity of type <see cref="TEntity"/> to add to the <see cref="DataResult{TEntity}"/> object.
        /// </param>
        /// <returns>
        ///     Returns a new instance of <see cref="DataResult{TEntity}"/> with the given <see cref="TEntity"/> inside it.
        /// </returns>
        public static new DataResult<TEntity> Success(TEntity entity)
        {
            return new DataResult<TEntity>
            {
                Entity = entity,
                Succeeded = true,
            };
        }

        /// <summary>
        ///     Adds a <see cref="DataError"/> to the new <see cref="DataResult{TEntity}"/> object.
        /// </summary>
        /// <param name="code">
        ///     The error code of the <see cref="DataError"/> object.
        /// </param>
        /// <param name="description">
        ///     The error description of the <see cref="DataError"/> object.
        /// </param>
        /// <returns>
        ///     a new <see cref="DataResult{TEntity}"/> object with the <see cref="DataError"/>.
        /// </returns>
        public static new DataResult<TEntity> WithError(string code, string description)
        {
            return new DataResult<TEntity>
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
        ///     Adds a <see cref="DataError"/> to the new <see cref="DataResult{TEntity}"/> object.
        /// </summary>
        /// <param name="error">
        ///     The <see cref="DataError"/> object to add to the <see cref="DataResult{TEntity}"/> objecjt.
        /// </param>
        /// <returns>
        ///     A new <see cref="DataResult{TEntity}"/> object with the <see cref="DataError"/>.
        /// </returns>
        public static new DataResult<TEntity> WithError(DataError error)
        {
            return new DataResult<TEntity>
            {
                Errors = new List<DataError>
                {
                    error,
                },
                Succeeded = false,
            };
        }

        /// <summary>
        ///     Adds a collection of <see cref="DataError"/> to the new <see cref="DataResult{TEntity}"/> object.
        /// </summary>
        /// <param name="errors">
        ///     The collection of <see cref="DataError"/> to add to the <see cref="DataResult{TEntity}"/> object.
        /// </param>
        /// <returns>
        ///     A new <see cref="DataResult{TEntity}"/> object with the collection of <see cref="DataError"/>.
        /// </returns>
        public static new DataResult<TEntity> WithError(ICollection<DataError> errors)
        {
            return new DataResult<TEntity>
            {
                Errors = errors,
                Succeeded = false,
            };
        }
    }
}