﻿using NUnit.Framework;
// ReSharper disable ConvertToAutoPropertyWhenPossible

[TestFixture]
public class BeforeAfterWithNoGetInfoCheckerTest
{

    [Test]
    public void WithGet()
    {
        var checker = new ModuleWeaver();

        var propertyDefinition = DefinitionFinder.FindProperty<BeforeAfterWithNoGetInfoCheckerTest>("PropertyWithGet");

        var message = checker.CheckForWarning(new PropertyData
        {
            PropertyDefinition = propertyDefinition,
        }, InvokerTypes.Before);
        Assert.IsNull(message);
    }

    [Test]
    public void NoGet()
    {
        var checker = new ModuleWeaver();

        var propertyDefinition = DefinitionFinder.FindProperty<BeforeAfterWithNoGetInfoCheckerTest>("PropertyNoGet");

        var message = checker.CheckForWarning(new PropertyData
        {
            PropertyDefinition = propertyDefinition,
        }, InvokerTypes.Before);
        Assert.IsNotNull(message);
    }




    string property;

    public string PropertyNoGet
    {
        set { property = value; }
    }
    public string PropertyWithGet
    {
        set { property = value; }
        get { return property; }
    }

}