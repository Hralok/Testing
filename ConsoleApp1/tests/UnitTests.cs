using ConsoleApp1;
using System;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("FUR")]
        [InlineData("FURF")]
        [InlineData("FYRYFIRUFIRUFURE")]
        [InlineData("FIREG")]
        public void MessageDecryption_UnCorrectTweet_ReturnNull(string value)
        {
            // Arrange
            string tweet = value;

            // Act
            var message = TweetDecoder.MessageDecryption(tweet);

            // Assert
            var result = message == null;

            Assert.True(result);
        }

        [Fact]
        public void Translate_1Fire_ReturnYouAreFired()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();

            support.count = 1;
            support.isItFire = true;
            data.Add(support);

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "You are fired!";

            Assert.True(result);
        }

        [Fact]
        public void Translate_2Fire_ReturnYouAndYouAreFired()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();

            support.count = 2;
            support.isItFire = true;
            data.Add(support);

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "You and you are fired!";

            Assert.True(result);
        }

        [Fact]
        public void Translate_1Fury_ReturnIAmFurious()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();

            support.count = 1;
            support.isItFire = false;
            data.Add(support);

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "I am furious.";

            Assert.True(result);
        }

        [Fact]
        public void Translate_2Fury_ReturnIAmReallyFurious()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();

            support.count = 2;
            support.isItFire = false;
            data.Add(support);

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "I am really furious.";

            Assert.True(result);
        }

        [Fact]
        public void Translate_1Fire1Fury_ReturnYouAreFiredIAmFurious()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();

            support.count = 1;
            support.isItFire = true;
            data.Add(support);
            support.isItFire = false;
            data.Add(support);

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "You are fired! I am furious.";

            Assert.True(result);
        }

        [Fact]
        public void Translate_EmptyData_ThrowException()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            string message;

            // Act
            // Assert

            Assert.Throws<NotImplementedException>( () => message = TweetDecoder.Translate(data));
        }

        [Fact]
        public void Translate_NullData_ReturnFakeTweet()
        {
            // Arrange
            List<TweetDecoder.centance> data = null;

            // Act
            var message = TweetDecoder.Translate(data);

            // Assert
            var result = message == "Fake tweet.";

            Assert.True(result);
        }

        [Fact]
        public void Translate_UnCorrectData_ThrowException()
        {
            // Arrange
            var data = new List<TweetDecoder.centance>();
            TweetDecoder.centance support = new TweetDecoder.centance();
            string message;

            support.count = -1;
            support.isItFire = false;
            data.Add(support);

            // Act
            // Assert

            Assert.Throws<NotImplementedException>( () => message = TweetDecoder.Translate(data));
        }
    }
}
