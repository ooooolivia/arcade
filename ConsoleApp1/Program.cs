using Microsoft.Build.Utilities;
using SignCheck;
using Xunit;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {


        }

        [Fact]
        public void SignCheckTest()
        {
            var InputFiles = new TaskItem[]
            {
                new TaskItem(@"C:\wf\tmp\signing-validation\Microsoft.NETCore.App.Runtime.browser-wasm.5.0.0-preview.6.20276.2.nupkg")
            };

            var ExclusionFile = @"C:\wf\tmp\signing-validation\SignCheckExclusionsFile.txt";

            var LogFile = @"C:\wf\tmp\signing-validation\LogFile.log";

            var ErrorLogFile = @"C:\wf\tmp\signing-validation\ErrorLogFile.log";

            var ArtifactsFolder = @"C:\wf\tmp\signing-validation\";

            var task = new SignCheckTask()
            {
                BuildEngine = new FakeBuildEngine(),
                Recursive = true,
                FileStatus = "AllFiles",
                InputFiles = InputFiles,
                ExclusionsFile = ExclusionFile,
                EnableJarSignatureVerification = false,
                VerifyStrongName = false,
                LogFile = LogFile,
                ErrorLogFile = ErrorLogFile,
                ArtifactFolder = ArtifactsFolder
            };

            Assert.True(task.Execute());
        }
    }
}
