# Unity PyramidGenerator
 Class for generating pyramid shaped meshes.  Not entirely finished/working.

# Usage
This script will create a pyramid shaped mesh from the origin point as the tip, to Vector3 a as the top left, and Vector3 d as bottom right.

Test example:
```cs
using Utilites

public void Test()
{
 Mesh msh = PyramidGenerator.GetMesh(new Vector3(0,10,0),new Vector3(-10,0,10),new Vector3(10,0,-10),new Quaternion(0,0,0,1))
}

```
