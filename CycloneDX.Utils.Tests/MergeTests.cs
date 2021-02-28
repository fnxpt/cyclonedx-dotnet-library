using System;
using System.Collections.Generic;
using Xunit;
using CycloneDX;
using CycloneDX.Models.v1_2;
using CycloneDX.Utils;

namespace CycloneDX.Utils.Tests
{
    public class MergeTests
    {
        [Fact]
        public void MergeToolsTest()
        {
            var sbom1 = new Bom
            {
                Metadata = new Metadata
                {
                    Tools = new List<Tool>
                    {
                        new Tool
                        {
                            Name = "Tool1",
                            Version = "1"
                        }
                    }
                }
            };
            var sbom2 = new Bom
            {
                Metadata = new Metadata
                {
                    Tools = new List<Tool>
                    {
                        new Tool
                        {
                            Name = "Tool2",
                            Version = "1"
                        }
                    }
                }
            };

            var result = CycloneDXUtils.Merge(sbom1, sbom2);

            Assert.Equal(2, result.Metadata.Tools.Count);
        }

        [Fact]
        public void MergeComponentsTest()
        {
            var sbom1 = new Bom
            {
                Components = new List<Component>
                {
                    new Component
                    {
                        Name = "Component1",
                        Version = "1"
                    }
                }
            };
            var sbom2 = new Bom
            {
                Components = new List<Component>
                {
                    new Component
                    {
                        Name = "Component2",
                        Version = "1"
                    }
                }
            };

            var result = CycloneDXUtils.Merge(sbom1, sbom2);

            Assert.Equal(2, result.Components.Count);
        }
    }
}