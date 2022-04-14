using ConsoleApp1;
using System;
using System.Collections.Generic;
using Xunit;

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















    }
}
