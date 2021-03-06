﻿namespace ReleaseNotesCompiler.Tests
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using ReleaseNotesCompiler;

    [TestFixture]
    public class ReleaseNotesBuilderIntegrationTests
    {
        [Explicit]
        [TestCase("NServiceBus", "5.1.0")]
        [TestCase("ServiceControl", "1.0.0-Beta4")]
        [TestCase("NServiceBus", "6.0.0")]
        public async Task GenerateReleaseNotes(string repo, string version)
        {
            var gitHubClient = ClientBuilder.Build();

            var releaseNotesBuilder = new ReleaseNotesBuilder(new DefaultGitHubClient(gitHubClient, "Particular", repo), "Particular", repo, version);
            var result = await releaseNotesBuilder.BuildReleaseNotes();
            Console.WriteLine(result);
            ClipBoardHelper.SetClipboard(result);
        }
    }
}
