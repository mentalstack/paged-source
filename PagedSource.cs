namespace PagedSource
{
    using System.Collections;
    using System.Collections.Generic;

    using System.Runtime;
    using System.Runtime.Serialization;

    using System;

    /// <summary>
    /// Paged items source.
    /// </summary>
    [Serializable]
    public class PagedSource<T> where T : new()
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        [DataMember]
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets is first page or not.
        /// </summary>
        [DataMember]
        public bool FirstPage { get { return PageIndex == 1; } }

        /// <summary>
        /// Gets is first page (index equals count) or not.
        /// </summary>
        [DataMember]
        public bool LastPage { get { return PageIndex >= PageCount; } }

        /// <summary>
        /// Gets or sets page count.
        /// </summary>
        [DataMember]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets total count.
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
        /// Constructor with specified parameters.
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