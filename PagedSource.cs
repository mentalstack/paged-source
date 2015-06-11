namespace PagedSource
{
    using System;

    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Paged data source.
    /// </summary>
    [Serializable]
    public class PagedSource<T> where T : new()
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets posts.
        /// </summary>
        [DataMember]
        public List<T> Items { get; set; }

        /// <summary>
        /// Check, is it the first page.
        /// </summary>
        [DataMember]
        public bool FirstPage { get { return PageIndex == 1; } }

        /// <summary>
        /// Check, is it the last (index equals count) page.
        /// </summary>
        [DataMember]
        public bool LastPage { get { return PageIndex >= PageCount; } }

        /// <summary>
        /// Gets or sets pages count.
        /// </summary>
        [DataMember]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets posts total count.
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets page index.
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PagedSource() { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        public PagedSource(List<T> items, int idx, int size, int total)
        {
            Items = items; // define list items

            TotalCount = total; PageCount = (int)Math.Ceiling(total / (double)size);
            {
                PageIndex = (idx + 1);
            }
        }

        #endregion
    }
}