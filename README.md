# ReStruct
ReStruct is a simple and light weight binary object serialisation / de-serialisation library for C#

## Objective
The main objective is to provide an easy way to define data structures and serialise them with **no** overheads. This is a naive approach when compared to modern serialisation techniques and libaries such as [protobuf](https://code.google.com/p/protobuf/) but often times such an approach is desirable when working with legacy systems where the protocol can't be redefined.

## Features
* Supports Big Endian and Little Endian formats
* Supports Unsigned integers, boolean, arrays and classes

## Documentation
### Class definition
```c#
using ReStruct.Serializer;

[ReStruct(Endianness.Big)]
public class ControlInfo
{
	public UInt32 Target;
	[ReStructArray(4)]
	public byte[] Vectors;
}

[ReStruct(Endianness.Big)]
public class Header
{
	public UInt32 CommandId;
	public ControlInfo ControlInfo;
}
```

### Serialisation
```c#
var mesage = new Header
{
    CommandId = 1,
    ControlInfo = new ControlInfo
    {
        Target = 200,
        Vectors = new byte[4] {0xaa, 0x55, 0xFF, 0x01}
    }
};
new BinarySerializer().Serialize(stream, message);
```

### DeSerialisation
```c#
var header = new BinarySerializer().Deserialize<Header>(stream);
```

## LICENSE
ReStruct is licensed under [MIT LICENSE](LICENSE)
