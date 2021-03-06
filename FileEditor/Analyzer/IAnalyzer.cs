﻿

namespace LogicDLL
{
    public interface IAnalyzer
    {
       // string[] InputAnalyzeLines { get; set; }
        string AnalyzerResult { get;  set; }
        /// <summary>
        /// Анализирует переданную строку на соответствие циклу while. Возвращает строку с результатом анализа
        /// </summary>
        /// <param name="Входная строка"></param>
        /// <returns></returns>
        //string Analyze(string[] lines);
        string Analyze(string lines);
        //string Check(string lines);
    }
}
