using ConsoleApp1;
using System;
using System.Collections.Generic;
using Xunit;
using System.IO;

namespace tests
{
    public class IntegrationTests
    {
        [Fact]
        public void ProcessATweet_Correct1FireTweet_ReturnCorrectAnswer()
        {
            // Arrange
            string tweet = "FIRE";

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "You are fired!";

            Assert.True(result);
        }

        [Fact]
        public void ProcessATweet_Correct2FireTweet_ReturnCorrectAnswer()
        {
            // Arrange
            string tweet = "FIREFIRE";

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "You and you are fired!";

            Assert.True(result);
        }

        [Fact]
        public void ProcessATweet_Correct1FuryTweet_ReturnCorrectAnswer()
        {
            // Arrange
            string tweet = "FURY";

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "I am furious.";

            Assert.True(result);
        }

        [Fact]
        public void ProcessATweet_Correct2FuryTweet_ReturnCorrectAnswer()
        {
            // Arrange
            string tweet = "FURYFURY";

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "I am really furious.";

            Assert.True(result);
        }
        [Fact]
        public void ProcessATweet_Correct1Fury1FireTweet_ReturnCorrectAnswer()
        {
            // Arrange
            string tweet = "FURYFIRE";

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "I am furious. You are fired!";

            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("FUR")]
        [InlineData("FURF")]
        [InlineData("FYRYFIRUFIRUFURE")]
        [InlineData("FIREG")]
        public void ProcessATweet_UnCorrectTweet_ReturnFakeTweet(string value)
        {
            // Arrange
            string tweet = value;

            // Act
            var message = TweetDecoder.ProcessATweet(tweet);

            // Assert
            var result = message == "Fake tweet.";

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_InputWithCorrectDataAndExistEmptyOutputFile_OutputFileWithCorrectOutput()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_1.txt", "FIRE");
            File.WriteAllText("output_IntegrationTest_1.txt", "");

            // Act
            TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_1",
                "output_IntegrationTest_1");

            // Assert
            var result = File.ReadAllLines(
                "output_IntegrationTest_1.txt")[0] == 
                "You are fired!" && File.ReadAllLines(
                "output_IntegrationTest_1.txt").Length == 1;

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_ExistInputWithUnCorrectDataAndExistEmptyOutputFile_OutputFileWithFakeTweetOutput()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_2.txt", "123");
            File.WriteAllText("output_IntegrationTest_2.txt", "");

            // Act
            TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_2",
                "output_IntegrationTest_2");

            // Assert
            var result = File.ReadAllLines(
                "output_IntegrationTest_2.txt")[0] ==
                "Fake tweet." && File.ReadAllLines(
                "output_IntegrationTest_2.txt").Length == 1;

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_UnExistInput_Exception()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_3.txt", "");
            File.WriteAllText("output_IntegrationTest_3.txt", "");

            File.Delete("input_IntegrationTest_3.txt");

            // Act
            // Assert

            Assert.Throws<FileNotFoundException>(() => TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_3",
                "output_IntegrationTest_3"));
        }



        [Fact]
        public void TranslateTweetsFromInputFile_InputWithCorrectDataAndUnExistOutputFile_OutputFileWithCorrectOutput()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_4.txt", "FIRE");
            File.WriteAllText("output_IntegrationTest_4.txt", "");

            File.Delete("output_IntegrationTest_4.txt");

            // Act
            TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_4",
                "output_IntegrationTest_4");

            // Assert
            var result = File.ReadAllLines(
                "output_IntegrationTest_4.txt")[0] ==
                "You are fired!" && File.ReadAllLines(
                "output_IntegrationTest_4.txt").Length == 1;

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_InputWithCorrectDataAndExistNotEmptyOutputFile_OutputFileWithCorrectOutput()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_5.txt", "FIRE");
            File.WriteAllText("output_IntegrationTest_5.txt", "Some text");

            // Act
            TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_5",
                "output_IntegrationTest_5");

            // Assert
            var result = File.ReadAllLines(
                "output_IntegrationTest_5.txt")[0] ==
                "You are fired!" && File.ReadAllLines(
                "output_IntegrationTest_5.txt").Length == 1;

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_InputWithManyCorrectData_OutputFileWithManyCorrectOutputs()
        {
            // Arrange
            File.WriteAllLines("input_IntegrationTest_6.txt", new string[] {"FIRE" , "FURY", "FIREFURY"});
            File.WriteAllText("output_IntegrationTest_6.txt", "");

            // Act
            TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_6",
                "output_IntegrationTest_6");

            // Assert
            var result = File.ReadAllLines(
                "output_IntegrationTest_6.txt")[0] ==
                "You are fired!" &&
                File.ReadAllLines(
                "output_IntegrationTest_6.txt")[1] ==
                "I am furious." &&
                File.ReadAllLines(
                "output_IntegrationTest_6.txt")[2] ==
                "You are fired! I am furious." &&
                File.ReadAllLines(
                "output_IntegrationTest_6.txt").Length == 3;

            Assert.True(result);
        }

        [Fact]
        public void TranslateTweetsFromInputFile_NullInput_Exception()
        {
            // Arrange
            File.WriteAllText("output_IntegrationTest_7.txt", "");

            // Act
            // Assert

            Assert.Throws<ArgumentNullException>(() => TweetDecoder.TranslateTweetsFromInputFile(
                null,
                "output_IntegrationTest_3"));
        }

        [Fact]
        public void TranslateTweetsFromInputFile_NullOutput_Exception()
        {
            // Arrange
            File.WriteAllText("input_IntegrationTest_8.txt", "FIRE");

            // Act
            // Assert

            Assert.Throws<ArgumentNullException>(() => TweetDecoder.TranslateTweetsFromInputFile(
                "input_IntegrationTest_8",
                null));
        }
    }
}
