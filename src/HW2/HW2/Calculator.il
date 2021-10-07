.class public auto ansi beforefieldinit
  HW2.Calculator
    extends System.Object
{
  .method public hidebysig static float64
    Calculate(
      int32 arg1,
      char operation,
      int32 arg2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] float64 result,
      [1] float64 V_1,
      [2] float64 V_2
    )
    
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    IL_0005: ldarg.1      // operation
    IL_0006: ldc.i4.s     42 // 0x2a
    IL_0008: sub
    IL_0009: switch       (IL_003d, IL_002f, IL_0054, IL_0036, IL_0054, IL_004c)
    IL_0026: br.s         IL_0028
    IL_0028: ldarg.1      // operation
    IL_0029: ldc.i4.s     58 // 0x3a
    IL_002b: beq.s        IL_0044
    IL_002d: br.s         IL_0054

    IL_002f: ldarg.0      // arg1
    IL_0030: ldarg.2      // arg2
    IL_0031: add
    IL_0032: conv.r8
    IL_0033: stloc.1      // V_1
    IL_0034: br.s         IL_0060

    IL_0036: ldarg.0      // arg1
    IL_0037: ldarg.2      // arg2
    IL_0038: sub
    IL_0039: conv.r8
    IL_003a: stloc.1      // V_1
    IL_003b: br.s         IL_0060

    IL_003d: ldarg.0      // arg1
    IL_003e: ldarg.2      // arg2
    IL_003f: mul
    IL_0040: conv.r8
    IL_0041: stloc.1      // V_1
    IL_0042: br.s         IL_0060

    IL_0044: ldarg.0      // arg1
    IL_0045: conv.r8
    IL_0046: ldarg.2      // arg2
    IL_0047: conv.r8
    IL_0048: div
    IL_0049: stloc.1      // V_1
    IL_004a: br.s         IL_0060

    IL_004c: ldarg.0      // arg1
    IL_004d: conv.r8
    IL_004e: ldarg.2      // arg2
    IL_004f: conv.r8
    IL_0050: div
    IL_0051: stloc.1      // V_1
    IL_0052: br.s         IL_0060

    IL_0054: ldc.r8       0.0
    IL_005d: stloc.1      // V_1
    IL_005e: br.s         IL_0060

    IL_0060: ldc.i4.1
    IL_0061: brtrue.s     IL_0064
    
    IL_0064: ldloc.1      // V_1
    IL_0065: stloc.0      // result

    IL_0066: ldloc.0      // result
    IL_0067: stloc.2      // V_2
    IL_0068: br.s         IL_006a
    
    IL_006a: ldloc.2      // V_2
    IL_006b: ret
  }

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8
    IL_0000: ldarg.0      // this
    IL_0001: call         instance void System.Object::.ctor()
    IL_0007: ret
  }
}