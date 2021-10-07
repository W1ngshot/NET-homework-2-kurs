.class public abstract sealed auto ansi beforefieldinit
  HW2.Parser
    extends System.Object
{
  .method public hidebysig static int32
    TryParse(
      string[] args,
      [out] int32& num1,
      [out] char& operation,
      [out] int32& num2
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] bool isFirstArgInt,
      [1] bool isOperationChar,
      [2] bool isSecondArgInt,
      [3] bool V_3,
      [4] bool V_4,
      [5] int32 V_5,
      [6] bool V_6,
      [7] bool V_7
    )

    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: clt
    IL_0007: stloc.3      // V_3

    IL_0008: ldloc.3      // V_3
    IL_0009: brfalse.s    IL_0011

    IL_000b: newobj       instance void [System.Runtime]System.ArgumentException::.ctor()
    IL_0010: throw

    IL_0011: ldarg.0      // args
    IL_0012: ldc.i4.0
    IL_0013: ldelem.ref
    IL_0014: ldarg.1      // num1
    IL_0015: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_001a: stloc.0      // isFirstArgInt

    IL_001b: ldarg.0      // args
    IL_001c: ldc.i4.1
    IL_001d: ldelem.ref
    IL_001e: ldarg.2      // operation
    IL_001f: call         bool [System.Runtime]System.Char::TryParse(string, char&)
    IL_0024: stloc.1      // isOperationChar

    IL_0025: ldarg.0      // args
    IL_0026: ldc.i4.2
    IL_0027: ldelem.ref
    IL_0028: ldarg.3      // num2
    IL_0029: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_002e: stloc.2      // isSecondArgInt

    IL_002f: ldloc.0      // isFirstArgInt
    IL_0030: ldloc.2      // isSecondArgInt
    IL_0031: and
    IL_0032: ldc.i4.0
    IL_0033: ceq
    IL_0035: stloc.s      V_4

    IL_0037: ldloc.s      V_4
    IL_0039: brfalse.s    IL_005a

    IL_003c: ldarg.0      // args
    IL_003d: ldc.i4.0
    IL_003e: ldelem.ref
    IL_003f: ldarg.0      // args
    IL_0040: ldc.i4.1
    IL_0041: ldelem.ref
    IL_0042: ldarg.0      // args
    IL_0043: ldc.i4.2
    IL_0044: ldelem.ref
    IL_0045: ldstr        " are not a valid arguments"
    IL_004a: call         string [System.Runtime]System.String::Concat(string, string, string, string)
    IL_004f: call         void [System.Console]System.Console::WriteLine(string)

    IL_0055: ldc.i4.1
    IL_0056: stloc.s      V_5
    IL_0058: br.s         IL_00d5

    IL_005a: ldloc.1      // isOperationChar
    IL_005b: brfalse.s    IL_0083
    IL_005d: ldarg.2      // operation
    IL_005e: ldind.u2
    IL_005f: ldc.i4.s     43 // 0x2b
    IL_0061: beq.s        IL_0080
    IL_0063: ldarg.2      // operation
    IL_0064: ldind.u2
    IL_0065: ldc.i4.s     45 // 0x2d
    IL_0067: beq.s        IL_0080
    IL_0069: ldarg.2      // operation
    IL_006a: ldind.u2
    IL_006b: ldc.i4.s     42 // 0x2a
    IL_006d: beq.s        IL_0080
    IL_006f: ldarg.2      // operation
    IL_0070: ldind.u2
    IL_0071: ldc.i4.s     47 // 0x2f
    IL_0073: beq.s        IL_0080
    IL_0075: ldarg.2      // operation
    IL_0076: ldind.u2
    IL_0077: ldc.i4.s     58 // 0x3a
    IL_0079: ceq
    IL_007b: ldc.i4.0
    IL_007c: ceq
    IL_007e: br.s         IL_0081
    IL_0080: ldc.i4.0
    IL_0081: br.s         IL_0084
    IL_0083: ldc.i4.1
    IL_0084: stloc.s      V_6

    IL_0086: ldloc.s      V_6
    IL_0088: brfalse.s    IL_00a3

    IL_008b: ldarg.0      // args
    IL_008c: ldc.i4.1
    IL_008d: ldelem.ref
    IL_008e: ldstr        " is not a supported operation"
    IL_0093: call         string [System.Runtime]System.String::Concat(string, string)
    IL_0098: call         void [System.Console]System.Console::WriteLine(string)

    IL_009e: ldc.i4.2
    IL_009f: stloc.s      V_5
    IL_00a1: br.s         IL_00d5

    IL_00a3: ldarg.3      // num2
    IL_00a4: ldind.i4
    IL_00a5: brtrue.s     IL_00b8
    IL_00a7: ldarg.2      // operation
    IL_00a8: ldind.u2
    IL_00a9: ldc.i4.s     47 // 0x2f
    IL_00ab: beq.s        IL_00b5
    IL_00ad: ldarg.2      // operation
    IL_00ae: ldind.u2
    IL_00af: ldc.i4.s     58 // 0x3a
    IL_00b1: ceq
    IL_00b3: br.s         IL_00b6
    IL_00b5: ldc.i4.1
    IL_00b6: br.s         IL_00b9
    IL_00b8: ldc.i4.0
    IL_00b9: stloc.s      V_7

    IL_00bb: ldloc.s      V_7
    IL_00bd: brfalse.s    IL_00d0

    IL_00c0: ldstr        "Dividing by zero"
    IL_00c5: call         void [System.Console]System.Console::WriteLine(string)

    IL_00cb: ldc.i4.3
    IL_00cc: stloc.s      V_5
    IL_00ce: br.s         IL_00d5

    IL_00d0: ldc.i4.0
    IL_00d1: stloc.s      V_5
    IL_00d3: br.s         IL_00d5

    IL_00d5: ldloc.s      V_5
    IL_00d7: ret
  }
}