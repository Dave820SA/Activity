using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class GateKey
    {
        public static List<GateQuestions> GetQuestions()
        {
            return new List<GateQuestions>{
                new GateQuestions{QuestionNumber = 1, Question="What's my name?", Answer= "puddintane"},
                new GateQuestions{QuestionNumber = 2, Question="I am the beginning of the end, and the end of time and space. I am essential to creation, and I surround every place. What am I?", Answer= "The letter e"},
                new GateQuestions{QuestionNumber = 3, Question="What always runs but never walks, often murmurs, never talks, has a bed but never sleeps, has a mouth but never eats?", Answer= "A river"},
                new GateQuestions{QuestionNumber = 4, Question="At night they come without being fetched. By day they are lost without being stolen. What are they?", Answer= "The stars"},
                new GateQuestions{QuestionNumber = 5, Question="What 80's video game inspired the modern rating system?", Answer= "Mortal Kombate"},
            };
        }
    }

    public class GateQuestions
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}