using System;
using System.Collections.Generic;
using ConsoleApp1;
using FileManager;

namespace ConsoleApp1
{
    public class TweetDecoder
    {
        public struct centance
        {
            public int count;
            public bool isItFire;
        }
        static void Main(string[] args)
        {
            
        }

        public static void TranslateTweetInputFile()
        {
            var input = ChadFile.GetInput();

            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = ProcessATweet(input[i]);
            }

            ChadFile.WriteOutput(output);
        }

        public static string ProcessATweet(string arg)
        {
            return Translate(MessageDecryption(arg));
        }

        public static List<centance> MessageDecryption(string message)
        {
            List<centance> decryptedMessage = new List<centance>();
            string alphabet = "EFIRUY";

            string fireWord = "FIRE";
            int currentFireChar = -1;

            string furyWord = "FURY";
            int currentFuryChar = -1;

            for (int i = 0; i < message.Length; i++)
            {
                if (!alphabet.Contains(message[i]))
                {
                    decryptedMessage = null;
                    break;
                }
                else
                {
                    if (message[i] == fireWord[currentFireChar + 1])
                    {
                        currentFireChar += 1;
                        if (currentFireChar == fireWord.Length - 1)
                        {
                            if (decryptedMessage.Count == 0 || !decryptedMessage[decryptedMessage.Count - 1].isItFire)
                            {
                                centance newCentance = new centance();
                                newCentance.count = 1;
                                newCentance.isItFire = true;
                                decryptedMessage.Add(newCentance);
                            }
                            else
                            {
                                var prop = decryptedMessage[decryptedMessage.Count - 1];
                                prop.count += 1;
                                decryptedMessage[decryptedMessage.Count - 1] = prop;
                            }
                            currentFuryChar = -1;
                            currentFireChar = -1;
                            continue;
                        }
                    }
                    else
                    {
                        currentFireChar = -1;
                    }

                    if (message[i] == furyWord[currentFuryChar + 1])
                    {
                        currentFuryChar += 1;
                        if (currentFuryChar == furyWord.Length - 1)
                        {
                            if (decryptedMessage.Count == 0 || decryptedMessage[decryptedMessage.Count - 1].isItFire)
                            {
                                centance newCentance = new centance();
                                newCentance.count = 1;
                                newCentance.isItFire = false;
                                decryptedMessage.Add(newCentance);
                            }
                            else
                            {
                                var prop = decryptedMessage[decryptedMessage.Count - 1];
                                prop.count += 1;
                                decryptedMessage[decryptedMessage.Count - 1] = prop;
                            }
                            currentFuryChar = -1;
                            currentFireChar = -1;
                            continue;
                        }
                    }
                    else
                    {
                        currentFuryChar = -1;
                    }
                }
            }

            if (decryptedMessage != null && decryptedMessage.Count == 0)
            {
                decryptedMessage = null;
            }

            return decryptedMessage;
        }

        public static string Translate(List<centance> decryptedMessage)
        {
            if (decryptedMessage == null)
            {
                return "Fake tweet.";
            }
            else
            {
                if (decryptedMessage.Count == 0)
                {
                    throw new NotImplementedException("Некорректные входные данные");
                }

                for (int i = 0; i < decryptedMessage.Count; i++)
                {
                    if (decryptedMessage[i].count < 1)
                    {
                        throw new NotImplementedException("Некорректные входные данные");
                    }
                }

                string message = "";

                for (int i = 0; i < decryptedMessage.Count; i++)
                {
                    if (message != "")
                    {
                        message += " ";
                    }

                    if (decryptedMessage[i].isItFire)
                    {
                        message += "You";

                        for (int j = 0; j < decryptedMessage[i].count - 1; j++)
                        {
                            message += " and you";
                        }

                        message += " are fired!";
                    }
                    else
                    {
                        message += "I am";

                        for (int j = 0; j < decryptedMessage[i].count - 1; j++)
                        {
                            message += " really";
                        }

                        message += " furious.";
                    }
                }


                return message;
            }





        }
















    }
}
