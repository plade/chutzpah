﻿namespace Chutzpah.FrameworkDefinitions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Chutzpah.FileProcessors;
    using HtmlAgilityPack;

    /// <summary>
    /// Definition that describes the Jasmine framework.
    /// </summary>
    public class JasmineDefinition : BaseFrameworkDefinition
    {
        private IReferencedFileProcessor lineNumberProcessor;

        private IEnumerable<string> fileDependencies;

        /// <summary>
        /// Constructs a new JasmineDefinition.
        /// </summary>
        public JasmineDefinition()
        {
            this.lineNumberProcessor = ChutzpahContainer.Current.GetInstance<JasmineLineNumberProcessor>();
            this.fileDependencies = base.FileDependencies.Concat(new string[] { "jasmine-html.js", "jasmine_favicon.png" });
        }

        /// <summary>
        /// Gets a processor to assign line numbers to tests.
        /// </summary>
        public override IReferencedFileProcessor LineNumberProcessor
        {
            get
            {
                return this.lineNumberProcessor;
            }
        }

        /// <summary>
        /// Gets a list of file dependencies to bundle with the Jasmine test harness.
        /// </summary>
        public override IEnumerable<string> FileDependencies
        {
            get
            {
                return this.fileDependencies;
            }
        }

        /// <summary>
        /// Gets a short, file system friendly key for the Jasmine library.
        /// </summary>
        protected override string FrameworkKey
        {
            get
            {
                return "jasmine";
            }
        }

        /// <summary>
        /// Gets a regular expression pattern to match a testable Jasmine file.
        /// </summary>
        protected override Regex FrameworkSignature
        {
            get
            {
                return RegexPatterns.JasmineTestRegex;
            }
        }

        /// <summary>
        /// Returns the node which will contain test fixture content.
        /// </summary>
        /// <param name="fixtureDocument">The document that contains the node.</param>
        /// <returns>The parent node of text fixture content.</returns>
        protected override HtmlNode GetFixtureNode(HtmlDocument fixtureDocument)
        {
            return fixtureDocument.DocumentNode.SelectSingleNode("/body");
        }
    }
}
