/*
Sniperkit-Bot
- Status: analyzed
*/

﻿using GVFS.FunctionalTests.Should;
using NUnit.Framework;

namespace GVFS.FunctionalTests.Tests.GitCommands
{
    [TestFixture]
    public class RmTests : GitRepoTests
    {
        public RmTests() : base(enlistmentPerTest: false)
        {
        }

        [TestCase]
        public void CanReadFileAfterGitRmDryRun()
        {
            this.ValidateGitCommand("status");

            // Validate that Readme.md is not on disk at all
            string fileName = "Readme.md";

            this.Enlistment.UnmountGVFS();
            this.Enlistment.GetVirtualPathTo(fileName).ShouldNotExistOnDisk(this.FileSystem);
            this.Enlistment.MountGVFS();
                    
            this.ValidateGitCommand("rm --dry-run " + fileName);
            this.FileContentsShouldMatch(fileName);
        }
    }
}
