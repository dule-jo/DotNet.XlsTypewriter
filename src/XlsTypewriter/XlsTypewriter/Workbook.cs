﻿using ClosedXML.Excel;

namespace XlsTypewriter;

public class Workbook : IDisposable
{
    private readonly List<Worksheet> _worksheets = new();

    private readonly XLWorkbook _workbook = new();

    public XLWorkbookProperties Properties => _workbook.Properties;

    public IXLCustomProperties CustomProperties => _workbook.CustomProperties;

    public void SaveAs(string path) => _workbook.SaveAs(path);

    public void SaveAs(Stream stream) => _workbook.SaveAs(stream);

    public Worksheet AddWorksheet(string name)
    {
        var worksheet = new Worksheet(_workbook.AddWorksheet(name));

        _worksheets.Add(worksheet);

        return worksheet;
    }

    public Worksheet GetWorksheet(string name)
    {
        return _worksheets.FirstOrDefault(w => w.Name == name);
    }

    public void Dispose()
    {
        _workbook.Dispose();
    }
}