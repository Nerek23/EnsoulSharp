using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200007C RID: 124
	public enum MessageId
	{
		// Token: 0x04000245 RID: 581
		MessageIdUnknown,
		// Token: 0x04000246 RID: 582
		MessageIdDeviceInputAssemblySetVertexBuffersHazard,
		// Token: 0x04000247 RID: 583
		MessageIdDeviceInputAssemblySetIndexBufferHazard,
		// Token: 0x04000248 RID: 584
		MessageIdDeviceVertexShaderSetShaderResourcesHazard,
		// Token: 0x04000249 RID: 585
		MessageIdDeviceVertexShaderSetConstantBuffersHazard,
		// Token: 0x0400024A RID: 586
		MessageIdDeviceGeometryShaderSetShaderResourcesHazard,
		// Token: 0x0400024B RID: 587
		MessageIdDeviceGeometryShaderSetConstantBuffersHazard,
		// Token: 0x0400024C RID: 588
		MessageIdDevicePixelShaderSetShaderResourcesHazard,
		// Token: 0x0400024D RID: 589
		MessageIdDevicePixelShaderSetConstantBuffersHazard,
		// Token: 0x0400024E RID: 590
		MessageIdDeviceOutputMergerSetRenderTargetsHazard,
		// Token: 0x0400024F RID: 591
		MessageIdDeviceStreamOutputSetTargetsHazard,
		// Token: 0x04000250 RID: 592
		MessageIdStringFromApplication,
		// Token: 0x04000251 RID: 593
		MessageIdCorruptedThis,
		// Token: 0x04000252 RID: 594
		MessageIdCorruptedParameter1,
		// Token: 0x04000253 RID: 595
		MessageIdCorruptedParameter2,
		// Token: 0x04000254 RID: 596
		MessageIdCorruptedParameter3,
		// Token: 0x04000255 RID: 597
		MessageIdCorruptedParameter4,
		// Token: 0x04000256 RID: 598
		MessageIdCorruptedParameter5,
		// Token: 0x04000257 RID: 599
		MessageIdCorruptedParameter6,
		// Token: 0x04000258 RID: 600
		MessageIdCorruptedParameter7,
		// Token: 0x04000259 RID: 601
		MessageIdCorruptedParameter8,
		// Token: 0x0400025A RID: 602
		MessageIdCorruptedParameter9,
		// Token: 0x0400025B RID: 603
		MessageIdCorruptedParameter10,
		// Token: 0x0400025C RID: 604
		MessageIdCorruptedParameter11,
		// Token: 0x0400025D RID: 605
		MessageIdCorruptedParameter12,
		// Token: 0x0400025E RID: 606
		MessageIdCorruptedParameter13,
		// Token: 0x0400025F RID: 607
		MessageIdCorruptedParameter14,
		// Token: 0x04000260 RID: 608
		MessageIdCorruptedParameter15,
		// Token: 0x04000261 RID: 609
		MessageIdCorruptedMultithreading,
		// Token: 0x04000262 RID: 610
		MessageIdMessageReportingOufOfMemory,
		// Token: 0x04000263 RID: 611
		MessageIdInputAssemblySetInputLayoutUnbindDeletingObject,
		// Token: 0x04000264 RID: 612
		MessageIdInputAssemblySetVertexBuffersUnbindDeletingObject,
		// Token: 0x04000265 RID: 613
		MessageIdInputAssemblySetIndexBufferUnbindDeletingObject,
		// Token: 0x04000266 RID: 614
		MessageIdVertexShaderSetShaderUnbindDeletingObject,
		// Token: 0x04000267 RID: 615
		MessageIdVertexShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x04000268 RID: 616
		MessageIdVertexShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x04000269 RID: 617
		MessageIdVertexShaderSetSamplersUnbindDeletingObject,
		// Token: 0x0400026A RID: 618
		MessageIdGeometryShaderSetShaderUnbindDeletingObject,
		// Token: 0x0400026B RID: 619
		MessageIdGeometryShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x0400026C RID: 620
		MessageIdGeometryShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x0400026D RID: 621
		MessageIdGeometryShaderSetSamplersUnbindDeletingObject,
		// Token: 0x0400026E RID: 622
		MessageIdStreamOutputSetTargetsUnbindDeletingObject,
		// Token: 0x0400026F RID: 623
		MessageIdPixelShaderSetShaderUnbindDeletingObject,
		// Token: 0x04000270 RID: 624
		MessageIdPixelShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x04000271 RID: 625
		MessageIdPixelShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x04000272 RID: 626
		MessageIdPixelShaderSetSamplersUnbindDeletingObject,
		// Token: 0x04000273 RID: 627
		MessageIdRasterizerSetStateUnbindDeletingObject,
		// Token: 0x04000274 RID: 628
		MessageIdOutputMergerSetBlendStateUnbindDeletingObject,
		// Token: 0x04000275 RID: 629
		MessageIdOutputMergerSetDepthStencilStateUnbindDeletingObject,
		// Token: 0x04000276 RID: 630
		MessageIdOutputMergerSetRenderTargetsUnbindDeletingObject,
		// Token: 0x04000277 RID: 631
		MessageIdSetPredicationUnbindDeletingObject,
		// Token: 0x04000278 RID: 632
		MessageIdGetPrivateDataMoreData,
		// Token: 0x04000279 RID: 633
		MessageIdSetPrivateDataInvalidFreeData,
		// Token: 0x0400027A RID: 634
		MessageIdSetPrivateDataInvalidIUnknown,
		// Token: 0x0400027B RID: 635
		MessageIdSetPrivateDataInvalidFlags,
		// Token: 0x0400027C RID: 636
		MessageIdSetPrivateDataChangingparams,
		// Token: 0x0400027D RID: 637
		MessageIdSetPrivateDataOufOfMemory,
		// Token: 0x0400027E RID: 638
		MessageIdCreateBufferUnrecognizedFormat,
		// Token: 0x0400027F RID: 639
		MessageIdCreateBufferInvalidSamples,
		// Token: 0x04000280 RID: 640
		MessageIdCreateBufferUnrecognizedUsage,
		// Token: 0x04000281 RID: 641
		MessageIdCreateBufferUnrecognizedBindFlags,
		// Token: 0x04000282 RID: 642
		MessageIdCreateBufferUnrecognizedCpuAccessFlags,
		// Token: 0x04000283 RID: 643
		MessageIdCreateBufferUnrecognizedMiscFlags,
		// Token: 0x04000284 RID: 644
		MessageIdCreateBufferInvalidCpuAccessFlags,
		// Token: 0x04000285 RID: 645
		MessageIdCreateBufferInvalidBindFlags,
		// Token: 0x04000286 RID: 646
		MessageIdCreateBufferInvalidInitialData,
		// Token: 0x04000287 RID: 647
		MessageIdCreateBufferInvalidDimensions,
		// Token: 0x04000288 RID: 648
		MessageIdCreateBufferInvalidMipLevels,
		// Token: 0x04000289 RID: 649
		MessageIdCreateBufferInvalidMiscFlags,
		// Token: 0x0400028A RID: 650
		MessageIdCreateBufferInvalidArgumentReturn,
		// Token: 0x0400028B RID: 651
		MessageIdCreateBufferOufOfMemoryReturn,
		// Token: 0x0400028C RID: 652
		MessageIdCreateBufferNullDescription,
		// Token: 0x0400028D RID: 653
		MessageIdCreateBufferInvalidConstantBufferBindingS,
		// Token: 0x0400028E RID: 654
		MessageIdCreateBufferLargeAllocation,
		// Token: 0x0400028F RID: 655
		MessageIdCreateTexture1DUnrecognizedFormat,
		// Token: 0x04000290 RID: 656
		MessageIdCreateTexture1DUnsupportedFormat,
		// Token: 0x04000291 RID: 657
		MessageIdCreateTexture1DInvalidSamples,
		// Token: 0x04000292 RID: 658
		MessageIdCreateTexture1DUnrecognizedUsage,
		// Token: 0x04000293 RID: 659
		MessageIdCreateTexture1DUnrecognizedBindFlags,
		// Token: 0x04000294 RID: 660
		MessageIdCreateTexture1DUnrecognizedCpuAccessFlags,
		// Token: 0x04000295 RID: 661
		MessageIdCreateTexture1DUnrecognizedMiscFlags,
		// Token: 0x04000296 RID: 662
		MessageIdCreateTexture1DInvalidCpuAccessFlags,
		// Token: 0x04000297 RID: 663
		MessageIdCreateTexture1DInvalidBindFlags,
		// Token: 0x04000298 RID: 664
		MessageIdCreateTexture1DInvalidInitialData,
		// Token: 0x04000299 RID: 665
		MessageIdCreateTexture1DInvalidDimensions,
		// Token: 0x0400029A RID: 666
		MessageIdCreateTexture1DInvalidMipLevels,
		// Token: 0x0400029B RID: 667
		MessageIdCreateTexture1DInvalidMiscFlags,
		// Token: 0x0400029C RID: 668
		MessageIdCreateTexture1DInvalidArgumentReturn,
		// Token: 0x0400029D RID: 669
		MessageIdCreateTexture1DOufOfMemoryReturn,
		// Token: 0x0400029E RID: 670
		MessageIdCreateTexture1DNullDescription,
		// Token: 0x0400029F RID: 671
		MessageIdCreateTexture1DLargeAllocation,
		// Token: 0x040002A0 RID: 672
		MessageIdCreateTexture2DUnrecognizedFormat,
		// Token: 0x040002A1 RID: 673
		MessageIdCreateTexture2DUnsupportedFormat,
		// Token: 0x040002A2 RID: 674
		MessageIdCreateTexture2DInvalidSamples,
		// Token: 0x040002A3 RID: 675
		MessageIdCreateTexture2DUnrecognizedUsage,
		// Token: 0x040002A4 RID: 676
		MessageIdCreateTexture2DUnrecognizedBindFlags,
		// Token: 0x040002A5 RID: 677
		MessageIdCreateTexture2DUnrecognizedCpuAccessFlags,
		// Token: 0x040002A6 RID: 678
		MessageIdCreateTexture2DUnrecognizedMiscFlags,
		// Token: 0x040002A7 RID: 679
		MessageIdCreateTexture2DInvalidCpuAccessFlags,
		// Token: 0x040002A8 RID: 680
		MessageIdCreateTexture2DInvalidBindFlags,
		// Token: 0x040002A9 RID: 681
		MessageIdCreateTexture2DInvalidInitialData,
		// Token: 0x040002AA RID: 682
		MessageIdCreateTexture2DInvalidDimensions,
		// Token: 0x040002AB RID: 683
		MessageIdCreateTexture2DInvalidMipLevels,
		// Token: 0x040002AC RID: 684
		MessageIdCreateTexture2DInvalidMiscFlags,
		// Token: 0x040002AD RID: 685
		MessageIdCreateTexture2DInvalidArgumentReturn,
		// Token: 0x040002AE RID: 686
		MessageIdCreateTexture2DOufOfMemoryReturn,
		// Token: 0x040002AF RID: 687
		MessageIdCreateTexture2DNullDescription,
		// Token: 0x040002B0 RID: 688
		MessageIdCreateTexture2DLargeAllocation,
		// Token: 0x040002B1 RID: 689
		MessageIdCreateTexture3DUnrecognizedFormat,
		// Token: 0x040002B2 RID: 690
		MessageIdCreateTexture3DUnsupportedFormat,
		// Token: 0x040002B3 RID: 691
		MessageIdCreateTexture3DInvalidSamples,
		// Token: 0x040002B4 RID: 692
		MessageIdCreateTexture3DUnrecognizedUsage,
		// Token: 0x040002B5 RID: 693
		MessageIdCreateTexture3DUnrecognizedBindFlags,
		// Token: 0x040002B6 RID: 694
		MessageIdCreateTexture3DUnrecognizedCpuAccessFlags,
		// Token: 0x040002B7 RID: 695
		MessageIdCreateTexture3DUnrecognizedMiscFlags,
		// Token: 0x040002B8 RID: 696
		MessageIdCreateTexture3DInvalidCpuAccessFlags,
		// Token: 0x040002B9 RID: 697
		MessageIdCreateTexture3DInvalidBindFlags,
		// Token: 0x040002BA RID: 698
		MessageIdCreateTexture3DInvalidInitialData,
		// Token: 0x040002BB RID: 699
		MessageIdCreateTexture3DInvalidDimensions,
		// Token: 0x040002BC RID: 700
		MessageIdCreateTexture3DInvalidMipLevels,
		// Token: 0x040002BD RID: 701
		MessageIdCreateTexture3DInvalidMiscFlags,
		// Token: 0x040002BE RID: 702
		MessageIdCreateTexture3DInvalidArgumentReturn,
		// Token: 0x040002BF RID: 703
		MessageIdCreateTexture3DOufOfMemoryReturn,
		// Token: 0x040002C0 RID: 704
		MessageIdCreateTexture3DNullDescription,
		// Token: 0x040002C1 RID: 705
		MessageIdCreateTexture3DLargeAllocation,
		// Token: 0x040002C2 RID: 706
		MessageIdCreateShaderResourceViewUnrecognizedFormat,
		// Token: 0x040002C3 RID: 707
		MessageIdCreateShaderResourceViewInvalidDescription,
		// Token: 0x040002C4 RID: 708
		MessageIdCreateShaderResourceViewInvalidFormat,
		// Token: 0x040002C5 RID: 709
		MessageIdCreateShaderResourceViewInvalidDimensions,
		// Token: 0x040002C6 RID: 710
		MessageIdCreateShaderResourceViewInvalidResource,
		// Token: 0x040002C7 RID: 711
		MessageIdCreateShaderResourceViewTooManyObjects,
		// Token: 0x040002C8 RID: 712
		MessageIdCreateShaderResourceViewInvalidArgumentReturn,
		// Token: 0x040002C9 RID: 713
		MessageIdCreateShaderResourceViewOufOfMemoryReturn,
		// Token: 0x040002CA RID: 714
		MessageIdCreateRenderTargetViewUnrecognizedFormat,
		// Token: 0x040002CB RID: 715
		MessageIdCreateRenderTargetViewUnsupportedFormat,
		// Token: 0x040002CC RID: 716
		MessageIdCreateRenderTargetViewInvalidDescription,
		// Token: 0x040002CD RID: 717
		MessageIdCreateRenderTargetViewInvalidFormat,
		// Token: 0x040002CE RID: 718
		MessageIdCreateRenderTargetViewInvalidDimensions,
		// Token: 0x040002CF RID: 719
		MessageIdCreateRenderTargetViewInvalidResource,
		// Token: 0x040002D0 RID: 720
		MessageIdCreateRenderTargetViewTooManyObjects,
		// Token: 0x040002D1 RID: 721
		MessageIdCreateRenderTargetViewInvalidArgumentReturn,
		// Token: 0x040002D2 RID: 722
		MessageIdCreateRenderTargetViewOufOfMemoryReturn,
		// Token: 0x040002D3 RID: 723
		MessageIdCreateDepthStencilViewUnrecognizedFormat,
		// Token: 0x040002D4 RID: 724
		MessageIdCreateDepthStencilViewInvalidDescription,
		// Token: 0x040002D5 RID: 725
		MessageIdCreateDepthStencilViewInvalidFormat,
		// Token: 0x040002D6 RID: 726
		MessageIdCreateDepthStencilViewInvalidDimensions,
		// Token: 0x040002D7 RID: 727
		MessageIdCreateDepthStencilViewInvalidResource,
		// Token: 0x040002D8 RID: 728
		MessageIdCreateDepthStencilViewTooManyObjects,
		// Token: 0x040002D9 RID: 729
		MessageIdCreateDepthStencilViewInvalidArgumentReturn,
		// Token: 0x040002DA RID: 730
		MessageIdCreateDepthStencilViewOufOfMemoryReturn,
		// Token: 0x040002DB RID: 731
		MessageIdCreateInputLayoutOufOfMemory,
		// Token: 0x040002DC RID: 732
		MessageIdCreateInputLayoutTooManyElements,
		// Token: 0x040002DD RID: 733
		MessageIdCreateInputLayoutInvalidFormat,
		// Token: 0x040002DE RID: 734
		MessageIdCreateInputLayoutIncompatibleformat,
		// Token: 0x040002DF RID: 735
		MessageIdCreateInputLayoutInvalidSlot,
		// Token: 0x040002E0 RID: 736
		MessageIdCreateInputLayoutInvalidInputsLotclass,
		// Token: 0x040002E1 RID: 737
		MessageIdCreateInputLayoutSteprateslotclassmismatch,
		// Token: 0x040002E2 RID: 738
		MessageIdCreateInputLayoutInvalidSlotClassChange,
		// Token: 0x040002E3 RID: 739
		MessageIdCreateInputLayoutInvalidStepratechange,
		// Token: 0x040002E4 RID: 740
		MessageIdCreateInputLayoutInvalidAlignment,
		// Token: 0x040002E5 RID: 741
		MessageIdCreateInputLayoutDuplicatesemantic,
		// Token: 0x040002E6 RID: 742
		MessageIdCreateInputLayoutUnparseableinputsignature,
		// Token: 0x040002E7 RID: 743
		MessageIdCreateInputLayoutNullSemantic,
		// Token: 0x040002E8 RID: 744
		MessageIdCreateInputLayoutMissingElement,
		// Token: 0x040002E9 RID: 745
		MessageIdCreateInputLayoutNullDescription,
		// Token: 0x040002EA RID: 746
		MessageIdCreateVertexShaderOufOfMemory,
		// Token: 0x040002EB RID: 747
		MessageIdCreateVertexShaderInvalidShaderBytecode,
		// Token: 0x040002EC RID: 748
		MessageIdCreateVertexShaderInvalidShaderType,
		// Token: 0x040002ED RID: 749
		MessageIdCreateGeometryShaderOufOfMemory,
		// Token: 0x040002EE RID: 750
		MessageIdCreateGeometryShaderInvalidShaderBytecode,
		// Token: 0x040002EF RID: 751
		MessageIdCreateGeometryShaderInvalidShaderType,
		// Token: 0x040002F0 RID: 752
		MessageIdCreateGeometryShaderWithStreamOutputOufOfMemory,
		// Token: 0x040002F1 RID: 753
		MessageIdCreateGeometryShaderWithStreamOutputInvalidShaderBytecode,
		// Token: 0x040002F2 RID: 754
		MessageIdCreateGeometryShaderWithStreamOutputInvalidShaderType,
		// Token: 0x040002F3 RID: 755
		MessageIdCreateGeometryShaderWithStreamOutputInvalidNumentries,
		// Token: 0x040002F4 RID: 756
		MessageIdCreateGeometryShaderWithStreamOutputOutputStreamsTrideunused,
		// Token: 0x040002F5 RID: 757
		MessageIdCreateGeometryShaderWithStreamOutputUnexpectedDeclaration,
		// Token: 0x040002F6 RID: 758
		MessageIdCreateGeometryShaderWithStreamOutputExpectedDeclaration,
		// Token: 0x040002F7 RID: 759
		MessageIdCreateGeometryShaderWithStreamOutputOutputSlot0expected,
		// Token: 0x040002F8 RID: 760
		MessageIdCreateGeometryShaderWithStreamOutputInvalidOutputSlot,
		// Token: 0x040002F9 RID: 761
		MessageIdCreateGeometryShaderWithStreamOutputOnlyoneelementperslot,
		// Token: 0x040002FA RID: 762
		MessageIdCreateGeometryShaderWithStreamOutputInvalidComponentcount,
		// Token: 0x040002FB RID: 763
		MessageIdCreateGeometryShaderWithStreamOutputInvalidStartcomponentandcomponentcount,
		// Token: 0x040002FC RID: 764
		MessageIdCreateGeometryShaderWithStreamOutputInvalidGapdefinition,
		// Token: 0x040002FD RID: 765
		MessageIdCreateGeometryShaderWithStreamOutputRepeatedoutput,
		// Token: 0x040002FE RID: 766
		MessageIdCreateGeometryShaderWithStreamOutputInvalidOutputStreamsTride,
		// Token: 0x040002FF RID: 767
		MessageIdCreateGeometryShaderWithStreamOutputMissingSemantic,
		// Token: 0x04000300 RID: 768
		MessageIdCreateGeometryShaderWithStreamOutputMaskmismatch,
		// Token: 0x04000301 RID: 769
		MessageIdCreateGeometryShaderWithStreamOutputCanthaveonlygaps,
		// Token: 0x04000302 RID: 770
		MessageIdCreateGeometryShaderWithStreamOutputDeclarationTooComplex,
		// Token: 0x04000303 RID: 771
		MessageIdCreateGeometryShaderWithStreamOutputMissingOutputSignature,
		// Token: 0x04000304 RID: 772
		MessageIdCreatePixelShaderOufOfMemory,
		// Token: 0x04000305 RID: 773
		MessageIdCreatePixelShaderInvalidShaderBytecode,
		// Token: 0x04000306 RID: 774
		MessageIdCreatePixelShaderInvalidShaderType,
		// Token: 0x04000307 RID: 775
		MessageIdCreateRasterizerstateInvalidFillmode,
		// Token: 0x04000308 RID: 776
		MessageIdCreateRasterizerstateInvalidCullmode,
		// Token: 0x04000309 RID: 777
		MessageIdCreateRasterizerstateInvalidDepthBiasclamp,
		// Token: 0x0400030A RID: 778
		MessageIdCreateRasterizerstateInvalidSlopescaleddepthbias,
		// Token: 0x0400030B RID: 779
		MessageIdCreateRasterizerstateTooManyObjects,
		// Token: 0x0400030C RID: 780
		MessageIdCreateRasterizerstateNullDescription,
		// Token: 0x0400030D RID: 781
		MessageIdCreateDepthStencilStateInvalidDepthWriteMask,
		// Token: 0x0400030E RID: 782
		MessageIdCreateDepthStencilStateInvalidDepthFunction,
		// Token: 0x0400030F RID: 783
		MessageIdCreateDepthStencilStateInvalidFrontfacestencilfailop,
		// Token: 0x04000310 RID: 784
		MessageIdCreateDepthStencilStateInvalidFrontfacestencilzfailop,
		// Token: 0x04000311 RID: 785
		MessageIdCreateDepthStencilStateInvalidFrontfacestencilpassop,
		// Token: 0x04000312 RID: 786
		MessageIdCreateDepthStencilStateInvalidFrontfacestencilfunc,
		// Token: 0x04000313 RID: 787
		MessageIdCreateDepthStencilStateInvalidBackfaceStencilFailop,
		// Token: 0x04000314 RID: 788
		MessageIdCreateDepthStencilStateInvalidBackfaceStencilZfailop,
		// Token: 0x04000315 RID: 789
		MessageIdCreateDepthStencilStateInvalidBackfaceStencilPassop,
		// Token: 0x04000316 RID: 790
		MessageIdCreateDepthStencilStateInvalidBackfaceStencilFunction,
		// Token: 0x04000317 RID: 791
		MessageIdCreateDepthStencilStateTooManyObjects,
		// Token: 0x04000318 RID: 792
		MessageIdCreateDepthStencilStateNullDescription,
		// Token: 0x04000319 RID: 793
		MessageIdCreateBlendStateInvalidSourceBlend,
		// Token: 0x0400031A RID: 794
		MessageIdCreateBlendStateInvalidDestinationBlend,
		// Token: 0x0400031B RID: 795
		MessageIdCreateBlendStateInvalidBlendOperation,
		// Token: 0x0400031C RID: 796
		MessageIdCreateBlendStateInvalidSourceBlendAlpha,
		// Token: 0x0400031D RID: 797
		MessageIdCreateBlendStateInvalidDestinationBlendAlpha,
		// Token: 0x0400031E RID: 798
		MessageIdCreateBlendStateInvalidBlendOperationAlpha,
		// Token: 0x0400031F RID: 799
		MessageIdCreateBlendStateInvalidRenderTargetWriteMask,
		// Token: 0x04000320 RID: 800
		MessageIdCreateBlendStateTooManyObjects,
		// Token: 0x04000321 RID: 801
		MessageIdCreateBlendStateNullDescription,
		// Token: 0x04000322 RID: 802
		MessageIdCreateSamplerStateInvalidFilter,
		// Token: 0x04000323 RID: 803
		MessageIdCreateSamplerStateInvalidAddressU,
		// Token: 0x04000324 RID: 804
		MessageIdCreateSamplerStateInvalidAddressV,
		// Token: 0x04000325 RID: 805
		MessageIdCreateSamplerStateInvalidAddressW,
		// Token: 0x04000326 RID: 806
		MessageIdCreateSamplerStateInvalidMiplodbias,
		// Token: 0x04000327 RID: 807
		MessageIdCreateSamplerStateInvalidMaximumAnisotropy,
		// Token: 0x04000328 RID: 808
		MessageIdCreateSamplerStateInvalidComparisonfunc,
		// Token: 0x04000329 RID: 809
		MessageIdCreateSamplerStateInvalidMinimumLod,
		// Token: 0x0400032A RID: 810
		MessageIdCreateSamplerStateInvalidMaximumLod,
		// Token: 0x0400032B RID: 811
		MessageIdCreateSamplerStateTooManyObjects,
		// Token: 0x0400032C RID: 812
		MessageIdCreateSamplerStateNullDescription,
		// Token: 0x0400032D RID: 813
		MessageIdCreateQueryOrpredicateInvalidQuery,
		// Token: 0x0400032E RID: 814
		MessageIdCreateQueryOrpredicateInvalidMiscFlags,
		// Token: 0x0400032F RID: 815
		MessageIdCreateQueryOrpredicateUnexpectedMiscFlags,
		// Token: 0x04000330 RID: 816
		MessageIdCreateQueryOrpredicateNullDescription,
		// Token: 0x04000331 RID: 817
		MessageIdDeviceInputAssemblySetPrimitivetopologyTopologyUnrecognized,
		// Token: 0x04000332 RID: 818
		MessageIdDeviceInputAssemblySetPrimitivetopologyTopologyUndefined,
		// Token: 0x04000333 RID: 819
		MessageIdInputAssemblySetVertexBuffersInvalidBuffer,
		// Token: 0x04000334 RID: 820
		MessageIdDeviceInputAssemblySetVertexBuffersOffsetTooLarge,
		// Token: 0x04000335 RID: 821
		MessageIdDeviceInputAssemblySetVertexBuffersBuffersEmpty,
		// Token: 0x04000336 RID: 822
		MessageIdInputAssemblySetIndexBufferInvalidBuffer,
		// Token: 0x04000337 RID: 823
		MessageIdDeviceInputAssemblySetIndexBufferFormatInvalid,
		// Token: 0x04000338 RID: 824
		MessageIdDeviceInputAssemblySetIndexBufferOffsetTooLarge,
		// Token: 0x04000339 RID: 825
		MessageIdDeviceInputAssemblySetIndexBufferOffsetUnaligned,
		// Token: 0x0400033A RID: 826
		MessageIdDeviceVertexShaderSetShaderResourcesViewsEmpty,
		// Token: 0x0400033B RID: 827
		MessageIdVertexShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x0400033C RID: 828
		MessageIdDeviceVertexShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x0400033D RID: 829
		MessageIdDeviceVertexShaderSetSamplersSamplersEmpty,
		// Token: 0x0400033E RID: 830
		MessageIdDeviceGeometryShaderSetShaderResourcesViewsEmpty,
		// Token: 0x0400033F RID: 831
		MessageIdGeometryShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x04000340 RID: 832
		MessageIdDeviceGeometryShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x04000341 RID: 833
		MessageIdDeviceGeometryShaderSetSamplersSamplersEmpty,
		// Token: 0x04000342 RID: 834
		MessageIdStreamOutputSetTargetsInvalidBuffer,
		// Token: 0x04000343 RID: 835
		MessageIdDeviceStreamOutputSetTargetsOffsetUnaligned,
		// Token: 0x04000344 RID: 836
		MessageIdDevicePixelShaderSetShaderResourcesViewsEmpty,
		// Token: 0x04000345 RID: 837
		MessageIdPixelShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x04000346 RID: 838
		MessageIdDevicePixelShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x04000347 RID: 839
		MessageIdDevicePixelShaderSetSamplersSamplersEmpty,
		// Token: 0x04000348 RID: 840
		MessageIdDeviceRasterizerSetViewportsInvalidViewport,
		// Token: 0x04000349 RID: 841
		MessageIdDeviceRasterizerSetScissorRectanglesInvalidScissor,
		// Token: 0x0400034A RID: 842
		MessageIdClearrendertargetviewDenormflush,
		// Token: 0x0400034B RID: 843
		MessageIdCleardepthstencilviewDenormflush,
		// Token: 0x0400034C RID: 844
		MessageIdCleardepthstencilviewInvalid,
		// Token: 0x0400034D RID: 845
		MessageIdDeviceInputAssemblyGetVertexBuffersBuffersEmpty,
		// Token: 0x0400034E RID: 846
		MessageIdDeviceVertexShaderGetShaderResourcesViewsEmpty,
		// Token: 0x0400034F RID: 847
		MessageIdDeviceVertexShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x04000350 RID: 848
		MessageIdDeviceVertexShaderGetSamplersSamplersEmpty,
		// Token: 0x04000351 RID: 849
		MessageIdDeviceGeometryShaderGetShaderResourcesViewsEmpty,
		// Token: 0x04000352 RID: 850
		MessageIdDeviceGeometryShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x04000353 RID: 851
		MessageIdDeviceGeometryShaderGetSamplersSamplersEmpty,
		// Token: 0x04000354 RID: 852
		MessageIdDeviceStreamOutputGetTargetsBuffersEmpty,
		// Token: 0x04000355 RID: 853
		MessageIdDevicePixelShaderGetShaderResourcesViewsEmpty,
		// Token: 0x04000356 RID: 854
		MessageIdDevicePixelShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x04000357 RID: 855
		MessageIdDevicePixelShaderGetSamplersSamplersEmpty,
		// Token: 0x04000358 RID: 856
		MessageIdDeviceRasterizerGetViewportsViewportsEmpty,
		// Token: 0x04000359 RID: 857
		MessageIdDeviceRasterizerGetScissorRectanglesRectanglesEmpty,
		// Token: 0x0400035A RID: 858
		MessageIdDeviceGeneratemipsResourceInvalid,
		// Token: 0x0400035B RID: 859
		MessageIdCopySubResourceRegionInvalidDestinationSubResource,
		// Token: 0x0400035C RID: 860
		MessageIdCopySubResourceRegionInvalidSourceSubResource,
		// Token: 0x0400035D RID: 861
		MessageIdCopySubResourceRegionInvalidSourceBox,
		// Token: 0x0400035E RID: 862
		MessageIdCopySubResourceRegionInvalidSource,
		// Token: 0x0400035F RID: 863
		MessageIdCopySubResourceRegionInvalidDestinationState,
		// Token: 0x04000360 RID: 864
		MessageIdCopySubResourceRegionInvalidSourceState,
		// Token: 0x04000361 RID: 865
		MessageIdCopyResourceInvalidSource,
		// Token: 0x04000362 RID: 866
		MessageIdCopyResourceInvalidDestinationState,
		// Token: 0x04000363 RID: 867
		MessageIdCopyResourceInvalidSourceState,
		// Token: 0x04000364 RID: 868
		MessageIdUpdatesUbresourceInvalidDestinationSubResource,
		// Token: 0x04000365 RID: 869
		MessageIdUpdatesUbresourceInvalidDestinationBox,
		// Token: 0x04000366 RID: 870
		MessageIdUpdatesUbresourceInvalidDestinationState,
		// Token: 0x04000367 RID: 871
		MessageIdDeviceResolvesubresourceDestinationInvalid,
		// Token: 0x04000368 RID: 872
		MessageIdDeviceResolvesubresourceDestinationSubResourceInvalid,
		// Token: 0x04000369 RID: 873
		MessageIdDeviceResolvesubresourceSourceInvalid,
		// Token: 0x0400036A RID: 874
		MessageIdDeviceResolvesubresourceSourceSubResourceInvalid,
		// Token: 0x0400036B RID: 875
		MessageIdDeviceResolvesubresourceFormatInvalid,
		// Token: 0x0400036C RID: 876
		MessageIdBufferMapInvalidMaptype,
		// Token: 0x0400036D RID: 877
		MessageIdBufferMapInvalidFlags,
		// Token: 0x0400036E RID: 878
		MessageIdBufferMapAlreadymapped,
		// Token: 0x0400036F RID: 879
		MessageIdBufferMapDeviceremovedReturn,
		// Token: 0x04000370 RID: 880
		MessageIdBufferUnmapNotMapped,
		// Token: 0x04000371 RID: 881
		MessageIdTexture1DMapInvalidMaptype,
		// Token: 0x04000372 RID: 882
		MessageIdTexture1DMapInvalidSubResource,
		// Token: 0x04000373 RID: 883
		MessageIdTexture1DMapInvalidFlags,
		// Token: 0x04000374 RID: 884
		MessageIdTexture1DMapAlreadymapped,
		// Token: 0x04000375 RID: 885
		MessageIdTexture1DMapDeviceremovedReturn,
		// Token: 0x04000376 RID: 886
		MessageIdTexture1DUnmapInvalidSubResource,
		// Token: 0x04000377 RID: 887
		MessageIdTexture1DUnmapNotMapped,
		// Token: 0x04000378 RID: 888
		MessageIdTexture2DMapInvalidMaptype,
		// Token: 0x04000379 RID: 889
		MessageIdTexture2DMapInvalidSubResource,
		// Token: 0x0400037A RID: 890
		MessageIdTexture2DMapInvalidFlags,
		// Token: 0x0400037B RID: 891
		MessageIdTexture2DMapAlreadymapped,
		// Token: 0x0400037C RID: 892
		MessageIdTexture2DMapDeviceremovedReturn,
		// Token: 0x0400037D RID: 893
		MessageIdTexture2DUnmapInvalidSubResource,
		// Token: 0x0400037E RID: 894
		MessageIdTexture2DUnmapNotMapped,
		// Token: 0x0400037F RID: 895
		MessageIdTexture3DMapInvalidMaptype,
		// Token: 0x04000380 RID: 896
		MessageIdTexture3DMapInvalidSubResource,
		// Token: 0x04000381 RID: 897
		MessageIdTexture3DMapInvalidFlags,
		// Token: 0x04000382 RID: 898
		MessageIdTexture3DMapAlreadymapped,
		// Token: 0x04000383 RID: 899
		MessageIdTexture3DMapDeviceremovedReturn,
		// Token: 0x04000384 RID: 900
		MessageIdTexture3DUnmapInvalidSubResource,
		// Token: 0x04000385 RID: 901
		MessageIdTexture3DUnmapNotMapped,
		// Token: 0x04000386 RID: 902
		MessageIdCheckFormatSupportFormatDeprecated,
		// Token: 0x04000387 RID: 903
		MessageIdCheckMultisamplequalitylevelsFormatDeprecated,
		// Token: 0x04000388 RID: 904
		MessageIdSetExceptionmodeUnrecognizedFlags,
		// Token: 0x04000389 RID: 905
		MessageIdSetExceptionmodeInvalidArgumentReturn,
		// Token: 0x0400038A RID: 906
		MessageIdSetExceptionmodeDeviceremovedReturn,
		// Token: 0x0400038B RID: 907
		MessageIdRefSimulatingInfinitelyFastHardware,
		// Token: 0x0400038C RID: 908
		MessageIdRefThreadingMode,
		// Token: 0x0400038D RID: 909
		MessageIdRefUmdriverException,
		// Token: 0x0400038E RID: 910
		MessageIdRefKmdriverException,
		// Token: 0x0400038F RID: 911
		MessageIdRefHardwareException,
		// Token: 0x04000390 RID: 912
		MessageIdRefAccessIngIndexAbleTempOutOfRange,
		// Token: 0x04000391 RID: 913
		MessageIdRefProblemParsingShader,
		// Token: 0x04000392 RID: 914
		MessageIdRefOutOfMemory,
		// Token: 0x04000393 RID: 915
		MessageIdRefInformation,
		// Token: 0x04000394 RID: 916
		MessageIdDeviceDrawVertexPosOverflow,
		// Token: 0x04000395 RID: 917
		MessageIdDeviceDrawIndexedIndexPosOverflow,
		// Token: 0x04000396 RID: 918
		MessageIdDeviceDrawInstancedVertexPosOverflow,
		// Token: 0x04000397 RID: 919
		MessageIdDeviceDrawInstancedInstancePosOverflow,
		// Token: 0x04000398 RID: 920
		MessageIdDeviceDrawIndexedInstancedInstancePosOverflow,
		// Token: 0x04000399 RID: 921
		MessageIdDeviceDrawIndexedInstancedIndexPosOverflow,
		// Token: 0x0400039A RID: 922
		MessageIdDeviceDrawVertexShaderNotSet,
		// Token: 0x0400039B RID: 923
		MessageIdDeviceShaderLinkageSemanticnameNotFound,
		// Token: 0x0400039C RID: 924
		MessageIdDeviceShaderLinkageRegisterindex,
		// Token: 0x0400039D RID: 925
		MessageIdDeviceShaderLinkageComponenttype,
		// Token: 0x0400039E RID: 926
		MessageIdDeviceShaderLinkageRegistermask,
		// Token: 0x0400039F RID: 927
		MessageIdDeviceShaderLinkageSystemvalue,
		// Token: 0x040003A0 RID: 928
		MessageIdDeviceShaderLinkageNeverwrittenAlwaysreads,
		// Token: 0x040003A1 RID: 929
		MessageIdDeviceDrawVertexBufferNotSet,
		// Token: 0x040003A2 RID: 930
		MessageIdDeviceDrawInputLayoutNotSet,
		// Token: 0x040003A3 RID: 931
		MessageIdDeviceDrawConstantBufferNotSet,
		// Token: 0x040003A4 RID: 932
		MessageIdDeviceDrawConstantBufferTooSmall,
		// Token: 0x040003A5 RID: 933
		MessageIdDeviceDrawSamplerNotSet,
		// Token: 0x040003A6 RID: 934
		MessageIdDeviceDrawShaderResourceViewNotSet,
		// Token: 0x040003A7 RID: 935
		MessageIdDeviceDrawViewDimensionMismatch,
		// Token: 0x040003A8 RID: 936
		MessageIdDeviceDrawVertexBufferStrideTooSmall,
		// Token: 0x040003A9 RID: 937
		MessageIdDeviceDrawVertexBufferTooSmall,
		// Token: 0x040003AA RID: 938
		MessageIdDeviceDrawIndexBufferNotSet,
		// Token: 0x040003AB RID: 939
		MessageIdDeviceDrawIndexBufferFormatInvalid,
		// Token: 0x040003AC RID: 940
		MessageIdDeviceDrawIndexBufferTooSmall,
		// Token: 0x040003AD RID: 941
		MessageIdDeviceDrawGeometryShaderInputPrimitiveMismatch,
		// Token: 0x040003AE RID: 942
		MessageIdDeviceDrawResourceReturnTypeMismatch,
		// Token: 0x040003AF RID: 943
		MessageIdDeviceDrawPositionNotPresent,
		// Token: 0x040003B0 RID: 944
		MessageIdDeviceDrawOutputStreamNotSet,
		// Token: 0x040003B1 RID: 945
		MessageIdDeviceDrawBoundResourceMapped,
		// Token: 0x040003B2 RID: 946
		MessageIdDeviceDrawInvalidPrimitivetopology,
		// Token: 0x040003B3 RID: 947
		MessageIdDeviceDrawVertexOffsetUnaligned,
		// Token: 0x040003B4 RID: 948
		MessageIdDeviceDrawVertexStrideUnaligned,
		// Token: 0x040003B5 RID: 949
		MessageIdDeviceDrawIndexOffsetUnaligned,
		// Token: 0x040003B6 RID: 950
		MessageIdDeviceDrawOutputStreamOffsetUnaligned,
		// Token: 0x040003B7 RID: 951
		MessageIdDeviceDrawResourceFormatLdUnsupported,
		// Token: 0x040003B8 RID: 952
		MessageIdDeviceDrawResourceFormatSampleUnsupported,
		// Token: 0x040003B9 RID: 953
		MessageIdDeviceDrawResourceFormatSampleCUnsupported,
		// Token: 0x040003BA RID: 954
		MessageIdDeviceDrawResourceMultisampleUnsupported,
		// Token: 0x040003BB RID: 955
		MessageIdDeviceDrawStreamOutputTargetsBoundWithoutSource,
		// Token: 0x040003BC RID: 956
		MessageIdDeviceDrawStreamOutputStrideLargeRThanBuffer,
		// Token: 0x040003BD RID: 957
		MessageIdDeviceDrawOutputMergerRenderTargetDoesNotSupportBlending,
		// Token: 0x040003BE RID: 958
		MessageIdDeviceDrawOutputMergerDualSourceBlendingCanOnlyHaveRenderTarget0,
		// Token: 0x040003BF RID: 959
		MessageIdDeviceRemovalProcessAtFault,
		// Token: 0x040003C0 RID: 960
		MessageIdDeviceRemovalProcessPossiblyAtFault,
		// Token: 0x040003C1 RID: 961
		MessageIdDeviceRemovalProcessNotAtFault,
		// Token: 0x040003C2 RID: 962
		MessageIdDeviceOpenSharedResourceInvalidArgumentReturn,
		// Token: 0x040003C3 RID: 963
		MessageIdDeviceOpenSharedResourceOufOfMemoryReturn,
		// Token: 0x040003C4 RID: 964
		MessageIdDeviceOpenSharedResourceBadinterfaceReturn,
		// Token: 0x040003C5 RID: 965
		MessageIdDeviceDrawViewportNotSet,
		// Token: 0x040003C6 RID: 966
		MessageIdCreateInputLayoutTrailingDigitInSemantic,
		// Token: 0x040003C7 RID: 967
		MessageIdCreateGeometryShaderWithStreamOutputTrailingDigitInSemantic,
		// Token: 0x040003C8 RID: 968
		MessageIdDeviceRasterizerSetViewportsDenormflush,
		// Token: 0x040003C9 RID: 969
		MessageIdOutputMergerSetRenderTargetsInvalidView,
		// Token: 0x040003CA RID: 970
		MessageIdDeviceSetTextFiltersizeInvalidDimensions,
		// Token: 0x040003CB RID: 971
		MessageIdDeviceDrawSamplerMismatch,
		// Token: 0x040003CC RID: 972
		MessageIdCreateInputLayoutTypeMismatch,
		// Token: 0x040003CD RID: 973
		MessageIdBlendStateGetDescriptionLegacy,
		// Token: 0x040003CE RID: 974
		MessageIdShaderResourceViewGetDescriptionLegacy,
		// Token: 0x040003CF RID: 975
		MessageIdCreateQueryOufOfMemoryReturn,
		// Token: 0x040003D0 RID: 976
		MessageIdCreatePredicateOufOfMemoryReturn,
		// Token: 0x040003D1 RID: 977
		MessageIdCreateCounterOufOfRangeCounter,
		// Token: 0x040003D2 RID: 978
		MessageIdCreateCounterSimultaneousActiveCountersExhausted,
		// Token: 0x040003D3 RID: 979
		MessageIdCreateCounterUnsupportedWellknownCounter,
		// Token: 0x040003D4 RID: 980
		MessageIdCreateCounterOufOfMemoryReturn,
		// Token: 0x040003D5 RID: 981
		MessageIdCreateCounterNonexclusiveReturn,
		// Token: 0x040003D6 RID: 982
		MessageIdCreateCounterNullDescription,
		// Token: 0x040003D7 RID: 983
		MessageIdCheckCounterOufOfRangeCounter,
		// Token: 0x040003D8 RID: 984
		MessageIdCheckCounterUnsupportedWellknownCounter,
		// Token: 0x040003D9 RID: 985
		MessageIdSetPredicationInvalidPredicateState,
		// Token: 0x040003DA RID: 986
		MessageIdQueryBeginUnsupported,
		// Token: 0x040003DB RID: 987
		MessageIdPredicateBeginDuringPredication,
		// Token: 0x040003DC RID: 988
		MessageIdQueryBeginDuplicate,
		// Token: 0x040003DD RID: 989
		MessageIdQueryBeginAbandoningPreviousResults,
		// Token: 0x040003DE RID: 990
		MessageIdPredicateEndDuringPredication,
		// Token: 0x040003DF RID: 991
		MessageIdQueryEndAbandoningPreviousResults,
		// Token: 0x040003E0 RID: 992
		MessageIdQueryEndWithoutBegin,
		// Token: 0x040003E1 RID: 993
		MessageIdQueryGetDataInvalidDataSize,
		// Token: 0x040003E2 RID: 994
		MessageIdQueryGetDataInvalidFlags,
		// Token: 0x040003E3 RID: 995
		MessageIdQueryGetDataInvalidCall,
		// Token: 0x040003E4 RID: 996
		MessageIdDeviceDrawPixelShaderOutputTypeMismatch,
		// Token: 0x040003E5 RID: 997
		MessageIdDeviceDrawResourceFormatGatherUnsupported,
		// Token: 0x040003E6 RID: 998
		MessageIdDeviceDrawInvalidUseOfCenterMultisamplePattern,
		// Token: 0x040003E7 RID: 999
		MessageIdDeviceInputAssemblySetVertexBuffersStrideTooLarge,
		// Token: 0x040003E8 RID: 1000
		MessageIdDeviceInputAssemblySetVertexBuffersInvalidRange,
		// Token: 0x040003E9 RID: 1001
		MessageIdCreateInputLayoutEmptyLayout,
		// Token: 0x040003EA RID: 1002
		MessageIdDeviceDrawResourceSampleCountMismatch,
		// Token: 0x040003EB RID: 1003
		MessageIdLiveObjectSummary,
		// Token: 0x040003EC RID: 1004
		MessageIdLiveBuffer,
		// Token: 0x040003ED RID: 1005
		MessageIdLiveTexture1D,
		// Token: 0x040003EE RID: 1006
		MessageIdLiveTexture2D,
		// Token: 0x040003EF RID: 1007
		MessageIdLiveTexture3D,
		// Token: 0x040003F0 RID: 1008
		MessageIdLiveShaderResourceView,
		// Token: 0x040003F1 RID: 1009
		MessageIdLiveRenderTargetView,
		// Token: 0x040003F2 RID: 1010
		MessageIdLiveDepthStencilView,
		// Token: 0x040003F3 RID: 1011
		MessageIdLiveVertexShader,
		// Token: 0x040003F4 RID: 1012
		MessageIdLiveGeometryShader,
		// Token: 0x040003F5 RID: 1013
		MessageIdLivePixelShader,
		// Token: 0x040003F6 RID: 1014
		MessageIdLiveInputLayout,
		// Token: 0x040003F7 RID: 1015
		MessageIdLiveSampler,
		// Token: 0x040003F8 RID: 1016
		MessageIdLiveBlendState,
		// Token: 0x040003F9 RID: 1017
		MessageIdLiveDepthStencilState,
		// Token: 0x040003FA RID: 1018
		MessageIdLiveRasterizerstate,
		// Token: 0x040003FB RID: 1019
		MessageIdLiveQuery,
		// Token: 0x040003FC RID: 1020
		MessageIdLivePredicate,
		// Token: 0x040003FD RID: 1021
		MessageIdLiveCounter,
		// Token: 0x040003FE RID: 1022
		MessageIdLiveDevice,
		// Token: 0x040003FF RID: 1023
		MessageIdLiveSwapchain,
		// Token: 0x04000400 RID: 1024
		MessageIdD3D10MessagesEnd,
		// Token: 0x04000401 RID: 1025
		MessageIdD3D10L9MessagesStart = 1048576,
		// Token: 0x04000402 RID: 1026
		MessageIdCreateDepthStencilStateStencilNoTwoSided,
		// Token: 0x04000403 RID: 1027
		MessageIdCreateRasterizerstateDepthBiasClampNotSupported,
		// Token: 0x04000404 RID: 1028
		MessageIdCreateSamplerStateNoComparisonSupport,
		// Token: 0x04000405 RID: 1029
		MessageIdCreateSamplerStateExcessiveAnisotropy,
		// Token: 0x04000406 RID: 1030
		MessageIdCreateSamplerStateBorderOutOfRange,
		// Token: 0x04000407 RID: 1031
		MessageIdVertexShaderSetSamplersNotSupported,
		// Token: 0x04000408 RID: 1032
		MessageIdVertexShaderSetSamplersTooManySamplers,
		// Token: 0x04000409 RID: 1033
		MessageIdPixelShaderSetSamplersTooManySamplers,
		// Token: 0x0400040A RID: 1034
		MessageIdCreateResourceNoArrays,
		// Token: 0x0400040B RID: 1035
		MessageIdCreateResourceNoVertexBufferAndIndexBufferBind,
		// Token: 0x0400040C RID: 1036
		MessageIdCreateResourceNoTexture1D,
		// Token: 0x0400040D RID: 1037
		MessageIdCreateResourceDimensionOutOfRange,
		// Token: 0x0400040E RID: 1038
		MessageIdCreateResourceNotBindableAsShaderResource,
		// Token: 0x0400040F RID: 1039
		MessageIdOutputMergerSetRenderTargetsTooManyRenderTargets,
		// Token: 0x04000410 RID: 1040
		MessageIdOutputMergerSetRenderTargetsNoDifferingBitDepthS,
		// Token: 0x04000411 RID: 1041
		MessageIdInputAssemblySetVertexBuffersBadBufferIndex,
		// Token: 0x04000412 RID: 1042
		MessageIdDeviceRasterizerSetViewportsTooManyViewports,
		// Token: 0x04000413 RID: 1043
		MessageIdDeviceInputAssemblySetPrimitivetopologyWithAdjacencyUnsupported,
		// Token: 0x04000414 RID: 1044
		MessageIdDeviceRasterizerSetScissorRectanglesTooManyScissors,
		// Token: 0x04000415 RID: 1045
		MessageIdCopyResourceOnlyTexture2DWithinGpuMemory,
		// Token: 0x04000416 RID: 1046
		MessageIdCopyResourceNoTexture3DReadback,
		// Token: 0x04000417 RID: 1047
		MessageIdCopyResourceNoTextureOnlyReadback,
		// Token: 0x04000418 RID: 1048
		MessageIdCreateInputLayoutUnsupportedFormat,
		// Token: 0x04000419 RID: 1049
		MessageIdCreateBlendStateNoAlphaToCoverage,
		// Token: 0x0400041A RID: 1050
		MessageIdCreateRasterizerstateDepthClipEnableMustBeTrue,
		// Token: 0x0400041B RID: 1051
		MessageIdDrawIndexedStartindexlocationMustBePositive,
		// Token: 0x0400041C RID: 1052
		MessageIdCreateShaderResourceViewMustUseLowestLod,
		// Token: 0x0400041D RID: 1053
		MessageIdCreateSamplerStateMinimumLodMustNotBeFractional,
		// Token: 0x0400041E RID: 1054
		MessageIdCreateSamplerStateMaximumLodMustBeFltMaximum,
		// Token: 0x0400041F RID: 1055
		MessageIdCreateShaderResourceViewFirstArraySliceMustBeZero,
		// Token: 0x04000420 RID: 1056
		MessageIdCreateShaderResourceViewCubeSMustHave6Sides,
		// Token: 0x04000421 RID: 1057
		MessageIdCreateResourceNotBindableAsRenderTarget,
		// Token: 0x04000422 RID: 1058
		MessageIdCreateResourceNoDwordIndexBuffer,
		// Token: 0x04000423 RID: 1059
		MessageIdCreateResourceMSAAPrecludesShaderResource,
		// Token: 0x04000424 RID: 1060
		MessageIdCreateResourcePresentationPrecludesShaderResource,
		// Token: 0x04000425 RID: 1061
		MessageIdCreateBlendStateNoIndependentBlendEnable,
		// Token: 0x04000426 RID: 1062
		MessageIdCreateBlendStateNoIndependentWriteMasks,
		// Token: 0x04000427 RID: 1063
		MessageIdCreateResourceNoStreamOut,
		// Token: 0x04000428 RID: 1064
		MessageIdCreateResourceOnlyVertexBufferIndexBufferForBuffers,
		// Token: 0x04000429 RID: 1065
		MessageIdCreateResourceNoAutogenForVolumes,
		// Token: 0x0400042A RID: 1066
		MessageIdCreateResourceDxgiFormatR8G8B8A8CannotBeShared,
		// Token: 0x0400042B RID: 1067
		MessageIdVertexShaderShaderResourcesNotSupported,
		// Token: 0x0400042C RID: 1068
		MessageIdGeometryShaderNotSupported,
		// Token: 0x0400042D RID: 1069
		MessageIdStreamOutNotSupported,
		// Token: 0x0400042E RID: 1070
		MessageIdTextFilterNotSupported,
		// Token: 0x0400042F RID: 1071
		MessageIdCreateBlendStateNoSeparateAlphaBlend,
		// Token: 0x04000430 RID: 1072
		MessageIdCreateBlendStateNoMrtBlend,
		// Token: 0x04000431 RID: 1073
		MessageIdCreateBlendStateOperationNotSupported,
		// Token: 0x04000432 RID: 1074
		MessageIdCreateSamplerStateNoMirrorOnce,
		// Token: 0x04000433 RID: 1075
		MessageIdDrawInstancedNotSupported,
		// Token: 0x04000434 RID: 1076
		MessageIdDrawIndexedInstancedNotSupportedBelow93,
		// Token: 0x04000435 RID: 1077
		MessageIdDrawIndexedPointListUnsupported,
		// Token: 0x04000436 RID: 1078
		MessageIdSetBlendStateSampleMaskCannotBeZero,
		// Token: 0x04000437 RID: 1079
		MessageIdCreateResourceDimensionExceedsFeatureLevelDefinition,
		// Token: 0x04000438 RID: 1080
		MessageIdCreateResourceOnlySingleMipLevelDepthStencilSupported,
		// Token: 0x04000439 RID: 1081
		MessageIdDeviceRasterizerSetScissorRectanglesNegativeScissor,
		// Token: 0x0400043A RID: 1082
		MessageIdSlotZeroMustBeD3D10InputPerVertexData,
		// Token: 0x0400043B RID: 1083
		MessageIdCreateResourceNonPow2Mipmap,
		// Token: 0x0400043C RID: 1084
		MessageIdCreateSamplerStateBorderNotSupported,
		// Token: 0x0400043D RID: 1085
		MessageIdOutputMergerSetRenderTargetsNoSRgbMrt,
		// Token: 0x0400043E RID: 1086
		MessageIdCopyResourceNo3DMismatchedUpdates,
		// Token: 0x0400043F RID: 1087
		MessageIdD3D10L9MessagesEnd,
		// Token: 0x04000440 RID: 1088
		MessageIdD3D11MessagesStart = 2097152,
		// Token: 0x04000441 RID: 1089
		MessageIdCreateDepthStencilViewInvalidFlags,
		// Token: 0x04000442 RID: 1090
		MessageIdCreateVertexShaderInvalidClassLinkage,
		// Token: 0x04000443 RID: 1091
		MessageIdCreateGeometryShaderInvalidClassLinkage,
		// Token: 0x04000444 RID: 1092
		MessageIdCreateGeometryShaderWithStreamOutputInvalidNumstreams,
		// Token: 0x04000445 RID: 1093
		MessageIdCreateGeometryShaderWithStreamOutputInvalidStreamTorasterizer,
		// Token: 0x04000446 RID: 1094
		MessageIdCreateGeometryShaderWithStreamOutputUnexpectedStreams,
		// Token: 0x04000447 RID: 1095
		MessageIdCreateGeometryShaderWithStreamOutputInvalidClassLinkage,
		// Token: 0x04000448 RID: 1096
		MessageIdCreatePixelShaderInvalidClassLinkage,
		// Token: 0x04000449 RID: 1097
		MessageIdCreateDeferredContextInvalidCommandlistflags,
		// Token: 0x0400044A RID: 1098
		MessageIdCreateDeferredContextSingleThreaded,
		// Token: 0x0400044B RID: 1099
		MessageIdCreateDeferredContextInvalidArgumentReturn,
		// Token: 0x0400044C RID: 1100
		MessageIdCreateDeferredContextInvalidCallReturn,
		// Token: 0x0400044D RID: 1101
		MessageIdCreateDeferredContextOufOfMemoryReturn,
		// Token: 0x0400044E RID: 1102
		MessageIdFinishDisplayListOnimmediatecontext,
		// Token: 0x0400044F RID: 1103
		MessageIdFinishDisplayListOufOfMemoryReturn,
		// Token: 0x04000450 RID: 1104
		MessageIdFinishDisplayListInvalidCallReturn,
		// Token: 0x04000451 RID: 1105
		MessageIdCreateGeometryShaderWithStreamOutputInvalidStream,
		// Token: 0x04000452 RID: 1106
		MessageIdCreateGeometryShaderWithStreamOutputUnexpectedEntries,
		// Token: 0x04000453 RID: 1107
		MessageIdCreateGeometryShaderWithStreamOutputUnexpectedStrides,
		// Token: 0x04000454 RID: 1108
		MessageIdCreateGeometryShaderWithStreamOutputInvalidNumstrides,
		// Token: 0x04000455 RID: 1109
		MessageIdDeviceHullShaderSetShaderResourcesHazard,
		// Token: 0x04000456 RID: 1110
		MessageIdDeviceHullShaderSetConstantBuffersHazard,
		// Token: 0x04000457 RID: 1111
		MessageIdHullShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x04000458 RID: 1112
		MessageIdHullShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x04000459 RID: 1113
		MessageIdCreateHullShaderInvalidCall,
		// Token: 0x0400045A RID: 1114
		MessageIdCreateHullShaderOufOfMemory,
		// Token: 0x0400045B RID: 1115
		MessageIdCreateHullShaderInvalidShaderBytecode,
		// Token: 0x0400045C RID: 1116
		MessageIdCreateHullShaderInvalidShaderType,
		// Token: 0x0400045D RID: 1117
		MessageIdCreateHullShaderInvalidClassLinkage,
		// Token: 0x0400045E RID: 1118
		MessageIdDeviceHullShaderSetShaderResourcesViewsEmpty,
		// Token: 0x0400045F RID: 1119
		MessageIdHullShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x04000460 RID: 1120
		MessageIdDeviceHullShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x04000461 RID: 1121
		MessageIdDeviceHullShaderSetSamplersSamplersEmpty,
		// Token: 0x04000462 RID: 1122
		MessageIdDeviceHullShaderGetShaderResourcesViewsEmpty,
		// Token: 0x04000463 RID: 1123
		MessageIdDeviceHullShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x04000464 RID: 1124
		MessageIdDeviceHullShaderGetSamplersSamplersEmpty,
		// Token: 0x04000465 RID: 1125
		MessageIdDeviceDomainShaderSetShaderResourcesHazard,
		// Token: 0x04000466 RID: 1126
		MessageIdDeviceDomainShaderSetConstantBuffersHazard,
		// Token: 0x04000467 RID: 1127
		MessageIdDomainShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x04000468 RID: 1128
		MessageIdDomainShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x04000469 RID: 1129
		MessageIdCreateDomainShaderInvalidCall,
		// Token: 0x0400046A RID: 1130
		MessageIdCreateDomainShaderOufOfMemory,
		// Token: 0x0400046B RID: 1131
		MessageIdCreateDomainShaderInvalidShaderBytecode,
		// Token: 0x0400046C RID: 1132
		MessageIdCreateDomainShaderInvalidShaderType,
		// Token: 0x0400046D RID: 1133
		MessageIdCreateDomainShaderInvalidClassLinkage,
		// Token: 0x0400046E RID: 1134
		MessageIdDeviceDomainShaderSetShaderResourcesViewsEmpty,
		// Token: 0x0400046F RID: 1135
		MessageIdDomainShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x04000470 RID: 1136
		MessageIdDeviceDomainShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x04000471 RID: 1137
		MessageIdDeviceDomainShaderSetSamplersSamplersEmpty,
		// Token: 0x04000472 RID: 1138
		MessageIdDeviceDomainShaderGetShaderResourcesViewsEmpty,
		// Token: 0x04000473 RID: 1139
		MessageIdDeviceDomainShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x04000474 RID: 1140
		MessageIdDeviceDomainShaderGetSamplersSamplersEmpty,
		// Token: 0x04000475 RID: 1141
		MessageIdDeviceDrawHullShaderXorDomainShaderMismatch,
		// Token: 0x04000476 RID: 1142
		MessageIdDeferredContextRemovalProcessAtFault,
		// Token: 0x04000477 RID: 1143
		MessageIdDeviceDrawIndirectInvalidArgumentBuffer,
		// Token: 0x04000478 RID: 1144
		MessageIdDeviceDrawIndirectOffsetUnaligned,
		// Token: 0x04000479 RID: 1145
		MessageIdDeviceDrawIndirectOffsetOverflow,
		// Token: 0x0400047A RID: 1146
		MessageIdResourceMapInvalidMaptype,
		// Token: 0x0400047B RID: 1147
		MessageIdResourceMapInvalidSubResource,
		// Token: 0x0400047C RID: 1148
		MessageIdResourceMapInvalidFlags,
		// Token: 0x0400047D RID: 1149
		MessageIdResourceMapAlreadymapped,
		// Token: 0x0400047E RID: 1150
		MessageIdResourceMapDeviceremovedReturn,
		// Token: 0x0400047F RID: 1151
		MessageIdResourceMapOufOfMemoryReturn,
		// Token: 0x04000480 RID: 1152
		MessageIdResourceMapWithoutInitialDiscard,
		// Token: 0x04000481 RID: 1153
		MessageIdResourceUnmapInvalidSubResource,
		// Token: 0x04000482 RID: 1154
		MessageIdResourceUnmapNotMapped,
		// Token: 0x04000483 RID: 1155
		MessageIdDeviceDrawRasterizingControlPoints,
		// Token: 0x04000484 RID: 1156
		MessageIdDeviceInputAssemblySetPrimitivetopologyTopologyUnsupported,
		// Token: 0x04000485 RID: 1157
		MessageIdDeviceDrawHullShaderDomainShaderSignatureMismatch,
		// Token: 0x04000486 RID: 1158
		MessageIdDeviceDrawHullShaderInputTopologyMismatch,
		// Token: 0x04000487 RID: 1159
		MessageIdDeviceDrawHullShaderDomainShaderControlPointCountMismatch,
		// Token: 0x04000488 RID: 1160
		MessageIdDeviceDrawHullShaderDomainShaderTessellatorDomainMismatch,
		// Token: 0x04000489 RID: 1161
		MessageIdCreateContext,
		// Token: 0x0400048A RID: 1162
		MessageIdLiveContext,
		// Token: 0x0400048B RID: 1163
		MessageIdDestroyContext,
		// Token: 0x0400048C RID: 1164
		MessageIdCreateBuffer,
		// Token: 0x0400048D RID: 1165
		MessageIdLiveBufferWin7,
		// Token: 0x0400048E RID: 1166
		MessageIdDestroyBuffer,
		// Token: 0x0400048F RID: 1167
		MessageIdCreateTexture1D,
		// Token: 0x04000490 RID: 1168
		MessageIdLiveTexture1DWin7,
		// Token: 0x04000491 RID: 1169
		MessageIdDestroyTexture1D,
		// Token: 0x04000492 RID: 1170
		MessageIdCreateTexture2D,
		// Token: 0x04000493 RID: 1171
		MessageIdLiveTexture2DWin7,
		// Token: 0x04000494 RID: 1172
		MessageIdDestroyTexture2D,
		// Token: 0x04000495 RID: 1173
		MessageIdCreateTexture3D,
		// Token: 0x04000496 RID: 1174
		MessageIdLiveTexture3DWin7,
		// Token: 0x04000497 RID: 1175
		MessageIdDestroyTexture3D,
		// Token: 0x04000498 RID: 1176
		MessageIdCreateShaderResourceView,
		// Token: 0x04000499 RID: 1177
		MessageIdLiveShaderResourceViewWin7,
		// Token: 0x0400049A RID: 1178
		MessageIdDestroyShaderResourceView,
		// Token: 0x0400049B RID: 1179
		MessageIdCreateRenderTargetView,
		// Token: 0x0400049C RID: 1180
		MessageIdLiveRenderTargetViewWin7,
		// Token: 0x0400049D RID: 1181
		MessageIdDestroyRenderTargetView,
		// Token: 0x0400049E RID: 1182
		MessageIdCreateDepthStencilView,
		// Token: 0x0400049F RID: 1183
		MessageIdLiveDepthStencilViewWin7,
		// Token: 0x040004A0 RID: 1184
		MessageIdDestroyDepthStencilView,
		// Token: 0x040004A1 RID: 1185
		MessageIdCreateVertexShader,
		// Token: 0x040004A2 RID: 1186
		MessageIdLiveVertexShaderWin7,
		// Token: 0x040004A3 RID: 1187
		MessageIdDestroyVertexShader,
		// Token: 0x040004A4 RID: 1188
		MessageIdCreateHullShader,
		// Token: 0x040004A5 RID: 1189
		MessageIdLiveHullShader,
		// Token: 0x040004A6 RID: 1190
		MessageIdDestroyHullShader,
		// Token: 0x040004A7 RID: 1191
		MessageIdCreateDomainShader,
		// Token: 0x040004A8 RID: 1192
		MessageIdLiveDomainShader,
		// Token: 0x040004A9 RID: 1193
		MessageIdDestroyDomainShader,
		// Token: 0x040004AA RID: 1194
		MessageIdCreateGeometryShader,
		// Token: 0x040004AB RID: 1195
		MessageIdLiveGeometryShaderWin7,
		// Token: 0x040004AC RID: 1196
		MessageIdDestroyGeometryShader,
		// Token: 0x040004AD RID: 1197
		MessageIdCreatePixelShader,
		// Token: 0x040004AE RID: 1198
		MessageIdLivePixelShaderWin7,
		// Token: 0x040004AF RID: 1199
		MessageIdDestroyPixelShader,
		// Token: 0x040004B0 RID: 1200
		MessageIdCreateInputLayout,
		// Token: 0x040004B1 RID: 1201
		MessageIdLiveInputLayoutWin7,
		// Token: 0x040004B2 RID: 1202
		MessageIdDestroyInputLayout,
		// Token: 0x040004B3 RID: 1203
		MessageIdCreateSampler,
		// Token: 0x040004B4 RID: 1204
		MessageIdLiveSamplerWin7,
		// Token: 0x040004B5 RID: 1205
		MessageIdDestroySampler,
		// Token: 0x040004B6 RID: 1206
		MessageIdCreateBlendState,
		// Token: 0x040004B7 RID: 1207
		MessageIdLiveBlendStateWin7,
		// Token: 0x040004B8 RID: 1208
		MessageIdDestroyBlendState,
		// Token: 0x040004B9 RID: 1209
		MessageIdCreateDepthStencilState,
		// Token: 0x040004BA RID: 1210
		MessageIdLiveDepthStencilStateWin7,
		// Token: 0x040004BB RID: 1211
		MessageIdDestroyDepthStencilState,
		// Token: 0x040004BC RID: 1212
		MessageIdCreateRasterizerstate,
		// Token: 0x040004BD RID: 1213
		MessageIdLiveRasterizerstateWin7,
		// Token: 0x040004BE RID: 1214
		MessageIdDestroyRasterizerstate,
		// Token: 0x040004BF RID: 1215
		MessageIdCreateQuery,
		// Token: 0x040004C0 RID: 1216
		MessageIdLiveQueryWin7,
		// Token: 0x040004C1 RID: 1217
		MessageIdDestroyQuery,
		// Token: 0x040004C2 RID: 1218
		MessageIdCreatePredicate,
		// Token: 0x040004C3 RID: 1219
		MessageIdLivePredicateWin7,
		// Token: 0x040004C4 RID: 1220
		MessageIdDestroyPredicate,
		// Token: 0x040004C5 RID: 1221
		MessageIdCreateCounter,
		// Token: 0x040004C6 RID: 1222
		MessageIdDestroyCounter,
		// Token: 0x040004C7 RID: 1223
		MessageIdCreateCommandlist,
		// Token: 0x040004C8 RID: 1224
		MessageIdLiveCommandlist,
		// Token: 0x040004C9 RID: 1225
		MessageIdDestroyCommandlist,
		// Token: 0x040004CA RID: 1226
		MessageIdCreateClassInstance,
		// Token: 0x040004CB RID: 1227
		MessageIdLiveClassInstance,
		// Token: 0x040004CC RID: 1228
		MessageIdDestroyClassInstance,
		// Token: 0x040004CD RID: 1229
		MessageIdCreateClassLinkage,
		// Token: 0x040004CE RID: 1230
		MessageIdLiveClassLinkage,
		// Token: 0x040004CF RID: 1231
		MessageIdDestroyClassLinkage,
		// Token: 0x040004D0 RID: 1232
		MessageIdLiveDeviceWin7,
		// Token: 0x040004D1 RID: 1233
		MessageIdLiveObjectSummaryWin7,
		// Token: 0x040004D2 RID: 1234
		MessageIdCreateComputeShader,
		// Token: 0x040004D3 RID: 1235
		MessageIdLiveComputeShader,
		// Token: 0x040004D4 RID: 1236
		MessageIdDestroyComputeShader,
		// Token: 0x040004D5 RID: 1237
		MessageIdCreateUnorderedAccessView,
		// Token: 0x040004D6 RID: 1238
		MessageIdLiveUnorderedAccessView,
		// Token: 0x040004D7 RID: 1239
		MessageIdDestroyUnorderedAccessView,
		// Token: 0x040004D8 RID: 1240
		MessageIdDeviceSetShaderInterfacesFeaturelevel,
		// Token: 0x040004D9 RID: 1241
		MessageIdDeviceSetShaderInterfaceCountMismatch,
		// Token: 0x040004DA RID: 1242
		MessageIdDeviceSetShaderInvalidInstance,
		// Token: 0x040004DB RID: 1243
		MessageIdDeviceSetShaderInvalidInstanceIndex,
		// Token: 0x040004DC RID: 1244
		MessageIdDeviceSetShaderInvalidInstanceType,
		// Token: 0x040004DD RID: 1245
		MessageIdDeviceSetShaderInvalidInstanceData,
		// Token: 0x040004DE RID: 1246
		MessageIdDeviceSetShaderUnboundInstanceData,
		// Token: 0x040004DF RID: 1247
		MessageIdDeviceSetShaderInstanceDataBindingS,
		// Token: 0x040004E0 RID: 1248
		MessageIdDeviceCreateShaderClassLinkageFull,
		// Token: 0x040004E1 RID: 1249
		MessageIdDeviceCheckFeaturesupportUnrecognizedFeature,
		// Token: 0x040004E2 RID: 1250
		MessageIdDeviceCheckFeaturesupportMismatchedDataSize,
		// Token: 0x040004E3 RID: 1251
		MessageIdDeviceCheckFeaturesupportInvalidArgumentReturn,
		// Token: 0x040004E4 RID: 1252
		MessageIdDeviceComputeShaderSetShaderResourcesHazard,
		// Token: 0x040004E5 RID: 1253
		MessageIdDeviceComputeShaderSetConstantBuffersHazard,
		// Token: 0x040004E6 RID: 1254
		MessageIdComputeShaderSetShaderResourcesUnbindDeletingObject,
		// Token: 0x040004E7 RID: 1255
		MessageIdComputeShaderSetConstantBuffersUnbindDeletingObject,
		// Token: 0x040004E8 RID: 1256
		MessageIdCreateComputeShaderInvalidCall,
		// Token: 0x040004E9 RID: 1257
		MessageIdCreateComputeShaderOufOfMemory,
		// Token: 0x040004EA RID: 1258
		MessageIdCreateComputeShaderInvalidShaderBytecode,
		// Token: 0x040004EB RID: 1259
		MessageIdCreateComputeShaderInvalidShaderType,
		// Token: 0x040004EC RID: 1260
		MessageIdCreateComputeShaderInvalidClassLinkage,
		// Token: 0x040004ED RID: 1261
		MessageIdDeviceComputeShaderSetShaderResourcesViewsEmpty,
		// Token: 0x040004EE RID: 1262
		MessageIdComputeShaderSetConstantBuffersInvalidBuffer,
		// Token: 0x040004EF RID: 1263
		MessageIdDeviceComputeShaderSetConstantBuffersBuffersEmpty,
		// Token: 0x040004F0 RID: 1264
		MessageIdDeviceComputeShaderSetSamplersSamplersEmpty,
		// Token: 0x040004F1 RID: 1265
		MessageIdDeviceComputeShaderGetShaderResourcesViewsEmpty,
		// Token: 0x040004F2 RID: 1266
		MessageIdDeviceComputeShaderGetConstantBuffersBuffersEmpty,
		// Token: 0x040004F3 RID: 1267
		MessageIdDeviceComputeShaderGetSamplersSamplersEmpty,
		// Token: 0x040004F4 RID: 1268
		MessageIdDeviceCreateVertexShaderDoubleFloatopsnotsupported,
		// Token: 0x040004F5 RID: 1269
		MessageIdDeviceCreateHullShaderDoubleFloatopsnotsupported,
		// Token: 0x040004F6 RID: 1270
		MessageIdDeviceCreateDomainShaderDoubleFloatopsnotsupported,
		// Token: 0x040004F7 RID: 1271
		MessageIdDeviceCreateGeometryShaderDoubleFloatopsnotsupported,
		// Token: 0x040004F8 RID: 1272
		MessageIdDeviceCreateGeometryShaderWithStreamOutputDoubleFloatopsnotsupported,
		// Token: 0x040004F9 RID: 1273
		MessageIdDeviceCreatePixelShaderDoubleFloatopsnotsupported,
		// Token: 0x040004FA RID: 1274
		MessageIdDeviceCreateComputeShaderDoubleFloatopsnotsupported,
		// Token: 0x040004FB RID: 1275
		MessageIdCreateBufferInvalidStructurestride,
		// Token: 0x040004FC RID: 1276
		MessageIdCreateShaderResourceViewInvalidFlags,
		// Token: 0x040004FD RID: 1277
		MessageIdCreateUnorderedAccessViewInvalidResource,
		// Token: 0x040004FE RID: 1278
		MessageIdCreateUnorderedAccessViewInvalidDescription,
		// Token: 0x040004FF RID: 1279
		MessageIdCreateUnorderedAccessViewInvalidFormat,
		// Token: 0x04000500 RID: 1280
		MessageIdCreateUnorderedAccessViewInvalidDimensions,
		// Token: 0x04000501 RID: 1281
		MessageIdCreateUnorderedAccessViewUnrecognizedFormat,
		// Token: 0x04000502 RID: 1282
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsHazard,
		// Token: 0x04000503 RID: 1283
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsOverlappingOldSlots,
		// Token: 0x04000504 RID: 1284
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsNoOperation,
		// Token: 0x04000505 RID: 1285
		MessageIdComputeShaderSetUnorderedAccessViewsUnbindDeletingObject,
		// Token: 0x04000506 RID: 1286
		MessageIdPixelShaderSetUnorderedAccessViewsUnbindDeletingObject,
		// Token: 0x04000507 RID: 1287
		MessageIdCreateUnorderedAccessViewInvalidArgumentReturn,
		// Token: 0x04000508 RID: 1288
		MessageIdCreateUnorderedAccessViewOufOfMemoryReturn,
		// Token: 0x04000509 RID: 1289
		MessageIdCreateUnorderedAccessViewTooManyObjects,
		// Token: 0x0400050A RID: 1290
		MessageIdDeviceComputeShaderSetUnorderedAccessViewsHazard,
		// Token: 0x0400050B RID: 1291
		MessageIdClearunorderedaccessviewDenormflush,
		// Token: 0x0400050C RID: 1292
		MessageIdDeviceComputeShaderSetUnorderedAccessSViewsEmpty,
		// Token: 0x0400050D RID: 1293
		MessageIdDeviceComputeShaderGetUnorderedAccessSViewsEmpty,
		// Token: 0x0400050E RID: 1294
		MessageIdCreateUnorderedAccessViewInvalidFlags,
		// Token: 0x0400050F RID: 1295
		MessageIdCreateShaderResesourceviewTooManyObjects,
		// Token: 0x04000510 RID: 1296
		MessageIdDeviceDispatchindirectInvalidArgumentBuffer,
		// Token: 0x04000511 RID: 1297
		MessageIdDeviceDispatchindirectOffsetUnaligned,
		// Token: 0x04000512 RID: 1298
		MessageIdDeviceDispatchindirectOffsetOverflow,
		// Token: 0x04000513 RID: 1299
		MessageIdDeviceSetResourceMinimumLodInvalidContext,
		// Token: 0x04000514 RID: 1300
		MessageIdDeviceSetResourceMinimumLodInvalidResource,
		// Token: 0x04000515 RID: 1301
		MessageIdDeviceSetResourceMinimumLodInvalidMinimumLod,
		// Token: 0x04000516 RID: 1302
		MessageIdDeviceGetResourceMinimumLodInvalidContext,
		// Token: 0x04000517 RID: 1303
		MessageIdDeviceGetResourceMinimumLodInvalidResource,
		// Token: 0x04000518 RID: 1304
		MessageIdOutputMergerSetDepthStencilUnbindDeletingObject,
		// Token: 0x04000519 RID: 1305
		MessageIdCleardepthstencilviewDepthReadonly,
		// Token: 0x0400051A RID: 1306
		MessageIdCleardepthstencilviewStencilReadonly,
		// Token: 0x0400051B RID: 1307
		MessageIdCheckFeaturesupportFormatDeprecated,
		// Token: 0x0400051C RID: 1308
		MessageIdDeviceUnorderedAccessViewReturnTypeMismatch,
		// Token: 0x0400051D RID: 1309
		MessageIdDeviceUnorderedAccessViewNotSet,
		// Token: 0x0400051E RID: 1310
		MessageIdDeviceDrawUnorderedAccessViewRenderTargetViewOverlap,
		// Token: 0x0400051F RID: 1311
		MessageIdDeviceUnorderedAccessViewDimensionMismatch,
		// Token: 0x04000520 RID: 1312
		MessageIdDeviceUnorderedAccessViewAppendUnsupported,
		// Token: 0x04000521 RID: 1313
		MessageIdDeviceUnorderedAccessViewAtomicsUnsupported,
		// Token: 0x04000522 RID: 1314
		MessageIdDeviceUnorderedAccessViewStructureStrideMismatch,
		// Token: 0x04000523 RID: 1315
		MessageIdDeviceUnorderedAccessViewBufferTypeMismatch,
		// Token: 0x04000524 RID: 1316
		MessageIdDeviceUnorderedAccessViewRawUnsupported,
		// Token: 0x04000525 RID: 1317
		MessageIdDeviceUnorderedAccessViewFormatLdUnsupported,
		// Token: 0x04000526 RID: 1318
		MessageIdDeviceUnorderedAccessViewFormatStoreUnsupported,
		// Token: 0x04000527 RID: 1319
		MessageIdDeviceUnorderedAccessViewAtomicAddUnsupported,
		// Token: 0x04000528 RID: 1320
		MessageIdDeviceUnorderedAccessViewAtomicBitwiseOperationsUnsupported,
		// Token: 0x04000529 RID: 1321
		MessageIdDeviceUnorderedAccessViewAtomicCmpstoreCmpexchangeUnsupported,
		// Token: 0x0400052A RID: 1322
		MessageIdDeviceUnorderedAccessViewAtomicExchangeUnsupported,
		// Token: 0x0400052B RID: 1323
		MessageIdDeviceUnorderedAccessViewAtomicSignedMinimumMaximumUnsupported,
		// Token: 0x0400052C RID: 1324
		MessageIdDeviceUnorderedAccessViewAtomicUnsignedMinimumMaximumUnsupported,
		// Token: 0x0400052D RID: 1325
		MessageIdDeviceDispatchBoundResourceMapped,
		// Token: 0x0400052E RID: 1326
		MessageIdDeviceDispatchThreadgroupcountOverflow,
		// Token: 0x0400052F RID: 1327
		MessageIdDeviceDispatchThreadgroupcountZero,
		// Token: 0x04000530 RID: 1328
		MessageIdDeviceShaderResourceViewStructureStrideMismatch,
		// Token: 0x04000531 RID: 1329
		MessageIdDeviceShaderResourceViewBufferTypeMismatch,
		// Token: 0x04000532 RID: 1330
		MessageIdDeviceShaderResourceViewRawUnsupported,
		// Token: 0x04000533 RID: 1331
		MessageIdDeviceDispatchUnsupported,
		// Token: 0x04000534 RID: 1332
		MessageIdDeviceDispatchindirectUnsupported,
		// Token: 0x04000535 RID: 1333
		MessageIdCopyStructurecountInvalidOffset,
		// Token: 0x04000536 RID: 1334
		MessageIdCopyStructurecountLargeOffset,
		// Token: 0x04000537 RID: 1335
		MessageIdCopyStructurecountInvalidDestinationState,
		// Token: 0x04000538 RID: 1336
		MessageIdCopyStructurecountInvalidSourceState,
		// Token: 0x04000539 RID: 1337
		MessageIdCheckFormatSupportFormatNotSupported,
		// Token: 0x0400053A RID: 1338
		MessageIdDeviceComputeShaderSetUnorderedAccessViewsInvalidView,
		// Token: 0x0400053B RID: 1339
		MessageIdDeviceComputeShaderSetUnorderedAccessViewsInvalidOffset,
		// Token: 0x0400053C RID: 1340
		MessageIdDeviceComputeShaderSetUnorderedAccessViewsTooManyViews,
		// Token: 0x0400053D RID: 1341
		MessageIdClearunorderedaccessviewfloatInvalidFormat,
		// Token: 0x0400053E RID: 1342
		MessageIdDeviceUnorderedAccessViewCounterUnsupported,
		// Token: 0x0400053F RID: 1343
		MessageIdRefWarning,
		// Token: 0x04000540 RID: 1344
		MessageIdDeviceDrawPixelShaderWithoutRenderTargetViewOrDepthStencilView,
		// Token: 0x04000541 RID: 1345
		MessageIdShaderAbort,
		// Token: 0x04000542 RID: 1346
		MessageIdShaderMessage,
		// Token: 0x04000543 RID: 1347
		MessageIdShaderError,
		// Token: 0x04000544 RID: 1348
		MessageIdOfferresourcesInvalidResource,
		// Token: 0x04000545 RID: 1349
		MessageIdHullShaderSetSamplersUnbindDeletingObject,
		// Token: 0x04000546 RID: 1350
		MessageIdDomainShaderSetSamplersUnbindDeletingObject,
		// Token: 0x04000547 RID: 1351
		MessageIdComputeShaderSetSamplersUnbindDeletingObject,
		// Token: 0x04000548 RID: 1352
		MessageIdHullShaderSetShaderUnbindDeletingObject,
		// Token: 0x04000549 RID: 1353
		MessageIdDomainShaderSetShaderUnbindDeletingObject,
		// Token: 0x0400054A RID: 1354
		MessageIdComputeShaderSetShaderUnbindDeletingObject,
		// Token: 0x0400054B RID: 1355
		MessageIdEnqueueSetEventInvalidArgumentReturn,
		// Token: 0x0400054C RID: 1356
		MessageIdEnqueueSetEventOufOfMemoryReturn,
		// Token: 0x0400054D RID: 1357
		MessageIdEnqueueSetEventAccessDeniedReturn,
		// Token: 0x0400054E RID: 1358
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsNumuavsInvalidRange,
		// Token: 0x0400054F RID: 1359
		MessageIdUseOfZeroRefcountObject,
		// Token: 0x04000550 RID: 1360
		MessageIdD3D11MessagesEnd,
		// Token: 0x04000551 RID: 1361
		MessageIdD3D111MessagesStart = 3145728,
		// Token: 0x04000552 RID: 1362
		MessageIdCreateVideoDecoder,
		// Token: 0x04000553 RID: 1363
		MessageIdCreateVideoProcessorEnum,
		// Token: 0x04000554 RID: 1364
		MessageIdCreateVideoProcessor,
		// Token: 0x04000555 RID: 1365
		MessageIdCreateDecoderoutputview,
		// Token: 0x04000556 RID: 1366
		MessageIdCreateProcessorInputView,
		// Token: 0x04000557 RID: 1367
		MessageIdCreateProcessorOutputView,
		// Token: 0x04000558 RID: 1368
		MessageIdCreateDevicecontextstate,
		// Token: 0x04000559 RID: 1369
		MessageIdLiveVideoDecoder,
		// Token: 0x0400055A RID: 1370
		MessageIdLiveVideoProcessorEnum,
		// Token: 0x0400055B RID: 1371
		MessageIdLiveVideoProcessor,
		// Token: 0x0400055C RID: 1372
		MessageIdLiveDecoderoutputview,
		// Token: 0x0400055D RID: 1373
		MessageIdLiveProcessorInputView,
		// Token: 0x0400055E RID: 1374
		MessageIdLiveProcessorOutputView,
		// Token: 0x0400055F RID: 1375
		MessageIdLiveDevicecontextstate,
		// Token: 0x04000560 RID: 1376
		MessageIdDestroyVideoDecoder,
		// Token: 0x04000561 RID: 1377
		MessageIdDestroyVideoProcessorEnum,
		// Token: 0x04000562 RID: 1378
		MessageIdDestroyVideoProcessor,
		// Token: 0x04000563 RID: 1379
		MessageIdDestroyDecoderoutputview,
		// Token: 0x04000564 RID: 1380
		MessageIdDestroyProcessorInputView,
		// Token: 0x04000565 RID: 1381
		MessageIdDestroyProcessorOutputView,
		// Token: 0x04000566 RID: 1382
		MessageIdDestroyDevicecontextstate,
		// Token: 0x04000567 RID: 1383
		MessageIdCreateDevicecontextstateInvalidFlags,
		// Token: 0x04000568 RID: 1384
		MessageIdCreateDevicecontextstateInvalidFeaturelevel,
		// Token: 0x04000569 RID: 1385
		MessageIdCreateDevicecontextstateFeaturelevelsNotSupported,
		// Token: 0x0400056A RID: 1386
		MessageIdCreateDevicecontextstateInvalidRefiid,
		// Token: 0x0400056B RID: 1387
		MessageIdDeviceDiscardviewInvalidView,
		// Token: 0x0400056C RID: 1388
		MessageIdCopySubResourceRegion1InvalidCopyFlags,
		// Token: 0x0400056D RID: 1389
		MessageIdUpdatesUbresource1InvalidCopyFlags,
		// Token: 0x0400056E RID: 1390
		MessageIdCreateRasterizerstateInvalidForcedSamplecount,
		// Token: 0x0400056F RID: 1391
		MessageIdCreateVideoDecoderOufOfMemoryReturn,
		// Token: 0x04000570 RID: 1392
		MessageIdCreateVideoDecoderNullParam,
		// Token: 0x04000571 RID: 1393
		MessageIdCreateVideoDecoderInvalidFormat,
		// Token: 0x04000572 RID: 1394
		MessageIdCreateVideoDecoderZerowidthheight,
		// Token: 0x04000573 RID: 1395
		MessageIdCreateVideoDecoderDriverInvalidBufferSize,
		// Token: 0x04000574 RID: 1396
		MessageIdCreateVideoDecoderDriverInvalidBufferUsage,
		// Token: 0x04000575 RID: 1397
		MessageIdGetVideoDecoderprofilecountOufOfMemory,
		// Token: 0x04000576 RID: 1398
		MessageIdGetVideoDecoderprofileNullParam,
		// Token: 0x04000577 RID: 1399
		MessageIdGetVideoDecoderprofileInvalidIndex,
		// Token: 0x04000578 RID: 1400
		MessageIdGetVideoDecoderprofileOufOfMemoryReturn,
		// Token: 0x04000579 RID: 1401
		MessageIdCheckVideoDecoderformatNullParam,
		// Token: 0x0400057A RID: 1402
		MessageIdCheckVideoDecoderformatOufOfMemoryReturn,
		// Token: 0x0400057B RID: 1403
		MessageIdGetVideoDecoderconfigcountNullParam,
		// Token: 0x0400057C RID: 1404
		MessageIdGetVideoDecoderconfigcountOufOfMemoryReturn,
		// Token: 0x0400057D RID: 1405
		MessageIdGetVideoDecoderconfigNullParam,
		// Token: 0x0400057E RID: 1406
		MessageIdGetVideoDecoderconfigInvalidIndex,
		// Token: 0x0400057F RID: 1407
		MessageIdGetVideoDecoderconfigOufOfMemoryReturn,
		// Token: 0x04000580 RID: 1408
		MessageIdGetDecodercreationparamsNullParam,
		// Token: 0x04000581 RID: 1409
		MessageIdGetDecoderdriverhandleNullParam,
		// Token: 0x04000582 RID: 1410
		MessageIdGetDecoderbufferNullParam,
		// Token: 0x04000583 RID: 1411
		MessageIdGetDecoderbufferInvalidBuffer,
		// Token: 0x04000584 RID: 1412
		MessageIdGetDecoderbufferInvalidType,
		// Token: 0x04000585 RID: 1413
		MessageIdGetDecoderbufferLocked,
		// Token: 0x04000586 RID: 1414
		MessageIdReleasedecoderbufferNullParam,
		// Token: 0x04000587 RID: 1415
		MessageIdReleasedecoderbufferInvalidType,
		// Token: 0x04000588 RID: 1416
		MessageIdReleasedecoderbufferNotLocked,
		// Token: 0x04000589 RID: 1417
		MessageIdDecoderbeginframeNullParam,
		// Token: 0x0400058A RID: 1418
		MessageIdDecoderbeginframeHazard,
		// Token: 0x0400058B RID: 1419
		MessageIdDecoderendframeNullParam,
		// Token: 0x0400058C RID: 1420
		MessageIdSubMitdecoderbuffersNullParam,
		// Token: 0x0400058D RID: 1421
		MessageIdSubMitdecoderbuffersInvalidType,
		// Token: 0x0400058E RID: 1422
		MessageIdDecoderextensionNullParam,
		// Token: 0x0400058F RID: 1423
		MessageIdDecoderextensionInvalidResource,
		// Token: 0x04000590 RID: 1424
		MessageIdCreateVideoProcessorEnumeratorOufOfMemoryReturn,
		// Token: 0x04000591 RID: 1425
		MessageIdCreateVideoProcessorEnumeratorNullParam,
		// Token: 0x04000592 RID: 1426
		MessageIdCreateVideoProcessorEnumeratorInvalidFrameFormat,
		// Token: 0x04000593 RID: 1427
		MessageIdCreateVideoProcessorEnumeratorInvalidUsage,
		// Token: 0x04000594 RID: 1428
		MessageIdCreateVideoProcessorEnumeratorInvalidInputFrameRate,
		// Token: 0x04000595 RID: 1429
		MessageIdCreateVideoProcessorEnumeratorInvalidOutputFrameRate,
		// Token: 0x04000596 RID: 1430
		MessageIdCreateVideoProcessorEnumeratorInvalidWidthheight,
		// Token: 0x04000597 RID: 1431
		MessageIdGetVideoProcessorContentdescNullParam,
		// Token: 0x04000598 RID: 1432
		MessageIdCheckVideoProcessorFormatNullParam,
		// Token: 0x04000599 RID: 1433
		MessageIdGetVideoProcessorCapsNullParam,
		// Token: 0x0400059A RID: 1434
		MessageIdGetVideoProcessorRateConversioncapsNullParam,
		// Token: 0x0400059B RID: 1435
		MessageIdGetVideoProcessorRateConversioncapsInvalidIndex,
		// Token: 0x0400059C RID: 1436
		MessageIdGetVideoProcessorCustomrateNullParam,
		// Token: 0x0400059D RID: 1437
		MessageIdGetVideoProcessorCustomrateInvalidIndex,
		// Token: 0x0400059E RID: 1438
		MessageIdGetVideoProcessorFilterrangeNullParam,
		// Token: 0x0400059F RID: 1439
		MessageIdGetVideoProcessorFilterrangeUnsupported,
		// Token: 0x040005A0 RID: 1440
		MessageIdCreateVideoProcessorOufOfMemoryReturn,
		// Token: 0x040005A1 RID: 1441
		MessageIdCreateVideoProcessorNullParam,
		// Token: 0x040005A2 RID: 1442
		MessageIdVideoProcessorSetOutputTargetRectangleNullParam,
		// Token: 0x040005A3 RID: 1443
		MessageIdVideoProcessorSetOutputBackgroundColorNullParam,
		// Token: 0x040005A4 RID: 1444
		MessageIdVideoProcessorSetOutputBackgroundColorInvalidAlpha,
		// Token: 0x040005A5 RID: 1445
		MessageIdVideoProcessorSetOutputColorSpaceNullParam,
		// Token: 0x040005A6 RID: 1446
		MessageIdVideoProcessorSetOutputAlphaFillmodeNullParam,
		// Token: 0x040005A7 RID: 1447
		MessageIdVideoProcessorSetOutputAlphaFillmodeUnsupported,
		// Token: 0x040005A8 RID: 1448
		MessageIdVideoProcessorSetOutputAlphaFillmodeInvalidStream,
		// Token: 0x040005A9 RID: 1449
		MessageIdVideoProcessorSetOutputAlphaFillmodeInvalidFillmode,
		// Token: 0x040005AA RID: 1450
		MessageIdVideoProcessorSetOutputConstrictionNullParam,
		// Token: 0x040005AB RID: 1451
		MessageIdVideoProcessorSetOutputStereoModeNullParam,
		// Token: 0x040005AC RID: 1452
		MessageIdVideoProcessorSetOutputStereoModeUnsupported,
		// Token: 0x040005AD RID: 1453
		MessageIdVideoProcessorSetOutputExtensionNullParam,
		// Token: 0x040005AE RID: 1454
		MessageIdVideoProcessorGetOutputTargetRectangleNullParam,
		// Token: 0x040005AF RID: 1455
		MessageIdVideoProcessorGetOutputBackgroundColorNullParam,
		// Token: 0x040005B0 RID: 1456
		MessageIdVideoProcessorGetOutputColorSpaceNullParam,
		// Token: 0x040005B1 RID: 1457
		MessageIdVideoProcessorGetOutputAlphaFillmodeNullParam,
		// Token: 0x040005B2 RID: 1458
		MessageIdVideoProcessorGetOutputConstrictionNullParam,
		// Token: 0x040005B3 RID: 1459
		MessageIdVideoProcessorSetOutputConstrictionUnsupported,
		// Token: 0x040005B4 RID: 1460
		MessageIdVideoProcessorSetOutputConstrictionInvalidSize,
		// Token: 0x040005B5 RID: 1461
		MessageIdVideoProcessorGetOutputStereoModeNullParam,
		// Token: 0x040005B6 RID: 1462
		MessageIdVideoProcessorGetOutputExtensionNullParam,
		// Token: 0x040005B7 RID: 1463
		MessageIdVideoProcessorSetStreamFrameFormatNullParam,
		// Token: 0x040005B8 RID: 1464
		MessageIdVideoProcessorSetStreamFrameFormatInvalidFormat,
		// Token: 0x040005B9 RID: 1465
		MessageIdVideoProcessorSetStreamFrameFormatInvalidStream,
		// Token: 0x040005BA RID: 1466
		MessageIdVideoProcessorSetStreamColorSpaceNullParam,
		// Token: 0x040005BB RID: 1467
		MessageIdVideoProcessorSetStreamColorSpaceInvalidStream,
		// Token: 0x040005BC RID: 1468
		MessageIdVideoProcessorSetStreamOutputRateNullParam,
		// Token: 0x040005BD RID: 1469
		MessageIdVideoProcessorSetStreamOutputRateInvalidRate,
		// Token: 0x040005BE RID: 1470
		MessageIdVideoProcessorSetStreamOutputRateInvalidFlags,
		// Token: 0x040005BF RID: 1471
		MessageIdVideoProcessorSetStreamOutputRateInvalidStream,
		// Token: 0x040005C0 RID: 1472
		MessageIdVideoProcessorSetStreamSourceRectangleNullParam,
		// Token: 0x040005C1 RID: 1473
		MessageIdVideoProcessorSetStreamSourceRectangleInvalidStream,
		// Token: 0x040005C2 RID: 1474
		MessageIdVideoProcessorSetStreamSourceRectangleInvalidRectangle,
		// Token: 0x040005C3 RID: 1475
		MessageIdVideoProcessorSetStreamDestinationRectangleNullParam,
		// Token: 0x040005C4 RID: 1476
		MessageIdVideoProcessorSetStreamDestinationRectangleInvalidStream,
		// Token: 0x040005C5 RID: 1477
		MessageIdVideoProcessorSetStreamDestinationRectangleInvalidRectangle,
		// Token: 0x040005C6 RID: 1478
		MessageIdVideoProcessorSetStreamAlphaNullParam,
		// Token: 0x040005C7 RID: 1479
		MessageIdVideoProcessorSetStreamAlphaInvalidStream,
		// Token: 0x040005C8 RID: 1480
		MessageIdVideoProcessorSetStreamAlphaInvalidAlpha,
		// Token: 0x040005C9 RID: 1481
		MessageIdVideoProcessorSetStreamPaletteNullParam,
		// Token: 0x040005CA RID: 1482
		MessageIdVideoProcessorSetStreamPaletteInvalidStream,
		// Token: 0x040005CB RID: 1483
		MessageIdVideoProcessorSetStreamPaletteInvalidCount,
		// Token: 0x040005CC RID: 1484
		MessageIdVideoProcessorSetStreamPaletteInvalidAlpha,
		// Token: 0x040005CD RID: 1485
		MessageIdVideoProcessorSetStreamPixelAspectRatioNullParam,
		// Token: 0x040005CE RID: 1486
		MessageIdVideoProcessorSetStreamPixelAspectRatioInvalidStream,
		// Token: 0x040005CF RID: 1487
		MessageIdVideoProcessorSetStreamPixelAspectRatioInvalidRatio,
		// Token: 0x040005D0 RID: 1488
		MessageIdVideoProcessorSetStreamLumakeyNullParam,
		// Token: 0x040005D1 RID: 1489
		MessageIdVideoProcessorSetStreamLumakeyInvalidStream,
		// Token: 0x040005D2 RID: 1490
		MessageIdVideoProcessorSetStreamLumakeyInvalidRange,
		// Token: 0x040005D3 RID: 1491
		MessageIdVideoProcessorSetStreamLumakeyUnsupported,
		// Token: 0x040005D4 RID: 1492
		MessageIdVideoProcessorSetStreamStereoFormatNullParam,
		// Token: 0x040005D5 RID: 1493
		MessageIdVideoProcessorSetStreamStereoFormatInvalidStream,
		// Token: 0x040005D6 RID: 1494
		MessageIdVideoProcessorSetStreamStereoFormatUnsupported,
		// Token: 0x040005D7 RID: 1495
		MessageIdVideoProcessorSetStreamStereoFormatFlipUnsupported,
		// Token: 0x040005D8 RID: 1496
		MessageIdVideoProcessorSetStreamStereoFormatMonoOffsetUnsupported,
		// Token: 0x040005D9 RID: 1497
		MessageIdVideoProcessorSetStreamStereoFormatFormatUnsupported,
		// Token: 0x040005DA RID: 1498
		MessageIdVideoProcessorSetStreamStereoFormatInvalidFormat,
		// Token: 0x040005DB RID: 1499
		MessageIdVideoProcessorSetStreamAutoprocessingmodeNullParam,
		// Token: 0x040005DC RID: 1500
		MessageIdVideoProcessorSetStreamAutoprocessingmodeInvalidStream,
		// Token: 0x040005DD RID: 1501
		MessageIdVideoProcessorSetStreamFilterNullParam,
		// Token: 0x040005DE RID: 1502
		MessageIdVideoProcessorSetStreamFilterInvalidStream,
		// Token: 0x040005DF RID: 1503
		MessageIdVideoProcessorSetStreamFilterInvalidFilter,
		// Token: 0x040005E0 RID: 1504
		MessageIdVideoProcessorSetStreamFilterUnsupported,
		// Token: 0x040005E1 RID: 1505
		MessageIdVideoProcessorSetStreamFilterInvalidLevel,
		// Token: 0x040005E2 RID: 1506
		MessageIdVideoProcessorSetStreamExtensionNullParam,
		// Token: 0x040005E3 RID: 1507
		MessageIdVideoProcessorSetStreamExtensionInvalidStream,
		// Token: 0x040005E4 RID: 1508
		MessageIdVideoProcessorGetStreamFrameFormatNullParam,
		// Token: 0x040005E5 RID: 1509
		MessageIdVideoProcessorGetStreamColorSpaceNullParam,
		// Token: 0x040005E6 RID: 1510
		MessageIdVideoProcessorGetStreamOutputRateNullParam,
		// Token: 0x040005E7 RID: 1511
		MessageIdVideoProcessorGetStreamSourceRectangleNullParam,
		// Token: 0x040005E8 RID: 1512
		MessageIdVideoProcessorGetStreamDestinationRectangleNullParam,
		// Token: 0x040005E9 RID: 1513
		MessageIdVideoProcessorGetStreamAlphaNullParam,
		// Token: 0x040005EA RID: 1514
		MessageIdVideoProcessorGetStreamPaletteNullParam,
		// Token: 0x040005EB RID: 1515
		MessageIdVideoProcessorGetStreamPixelAspectRatioNullParam,
		// Token: 0x040005EC RID: 1516
		MessageIdVideoProcessorGetStreamLumakeyNullParam,
		// Token: 0x040005ED RID: 1517
		MessageIdVideoProcessorGetStreamStereoFormatNullParam,
		// Token: 0x040005EE RID: 1518
		MessageIdVideoProcessorGetStreamAutoprocessingmodeNullParam,
		// Token: 0x040005EF RID: 1519
		MessageIdVideoProcessorGetStreamFilterNullParam,
		// Token: 0x040005F0 RID: 1520
		MessageIdVideoProcessorGetStreamExtensionNullParam,
		// Token: 0x040005F1 RID: 1521
		MessageIdVideoProcessorGetStreamExtensionInvalidStream,
		// Token: 0x040005F2 RID: 1522
		MessageIdVideoProcessorBlitNullParam,
		// Token: 0x040005F3 RID: 1523
		MessageIdVideoProcessorBlitInvalidStreamCount,
		// Token: 0x040005F4 RID: 1524
		MessageIdVideoProcessorBlitTargetRectangle,
		// Token: 0x040005F5 RID: 1525
		MessageIdVideoProcessorBlitInvalidOutput,
		// Token: 0x040005F6 RID: 1526
		MessageIdVideoProcessorBlitInvalidPastframes,
		// Token: 0x040005F7 RID: 1527
		MessageIdVideoProcessorBlitInvalidFutureFrames,
		// Token: 0x040005F8 RID: 1528
		MessageIdVideoProcessorBlitInvalidSourceRectangle,
		// Token: 0x040005F9 RID: 1529
		MessageIdVideoProcessorBlitInvalidDestinationRectangle,
		// Token: 0x040005FA RID: 1530
		MessageIdVideoProcessorBlitInvalidInputResource,
		// Token: 0x040005FB RID: 1531
		MessageIdVideoProcessorBlitInvalidArraySize,
		// Token: 0x040005FC RID: 1532
		MessageIdVideoProcessorBlitInvalidArray,
		// Token: 0x040005FD RID: 1533
		MessageIdVideoProcessorBlitRightexpected,
		// Token: 0x040005FE RID: 1534
		MessageIdVideoProcessorBlitRightnotexpected,
		// Token: 0x040005FF RID: 1535
		MessageIdVideoProcessorBlitStereoNotEnabled,
		// Token: 0x04000600 RID: 1536
		MessageIdVideoProcessorBlitInvalidRightresource,
		// Token: 0x04000601 RID: 1537
		MessageIdVideoProcessorBlitNostereostreams,
		// Token: 0x04000602 RID: 1538
		MessageIdVideoProcessorBlitInputHazard,
		// Token: 0x04000603 RID: 1539
		MessageIdVideoProcessorBlitOutputHazard,
		// Token: 0x04000604 RID: 1540
		MessageIdCreateVideoDecoderoutputviewOufOfMemoryReturn,
		// Token: 0x04000605 RID: 1541
		MessageIdCreateVideoDecoderoutputviewNullParam,
		// Token: 0x04000606 RID: 1542
		MessageIdCreateVideoDecoderoutputviewInvalidType,
		// Token: 0x04000607 RID: 1543
		MessageIdCreateVideoDecoderoutputviewInvalidBind,
		// Token: 0x04000608 RID: 1544
		MessageIdCreateVideoDecoderoutputviewUnsupportedFormat,
		// Token: 0x04000609 RID: 1545
		MessageIdCreateVideoDecoderoutputviewInvalidMip,
		// Token: 0x0400060A RID: 1546
		MessageIdCreateVideoDecoderoutputviewUnsupportemip,
		// Token: 0x0400060B RID: 1547
		MessageIdCreateVideoDecoderoutputviewInvalidArraySize,
		// Token: 0x0400060C RID: 1548
		MessageIdCreateVideoDecoderoutputviewInvalidArray,
		// Token: 0x0400060D RID: 1549
		MessageIdCreateVideoDecoderoutputviewInvalidDimension,
		// Token: 0x0400060E RID: 1550
		MessageIdCreateVideoProcessorInputViewOufOfMemoryReturn,
		// Token: 0x0400060F RID: 1551
		MessageIdCreateVideoProcessorInputViewNullParam,
		// Token: 0x04000610 RID: 1552
		MessageIdCreateVideoProcessorInputViewInvalidType,
		// Token: 0x04000611 RID: 1553
		MessageIdCreateVideoProcessorInputViewInvalidBind,
		// Token: 0x04000612 RID: 1554
		MessageIdCreateVideoProcessorInputViewInvalidMisc,
		// Token: 0x04000613 RID: 1555
		MessageIdCreateVideoProcessorInputViewInvalidUsage,
		// Token: 0x04000614 RID: 1556
		MessageIdCreateVideoProcessorInputViewInvalidFormat,
		// Token: 0x04000615 RID: 1557
		MessageIdCreateVideoProcessorInputViewInvalidFourcc,
		// Token: 0x04000616 RID: 1558
		MessageIdCreateVideoProcessorInputViewInvalidMip,
		// Token: 0x04000617 RID: 1559
		MessageIdCreateVideoProcessorInputViewUnsupportedMip,
		// Token: 0x04000618 RID: 1560
		MessageIdCreateVideoProcessorInputViewInvalidArraySize,
		// Token: 0x04000619 RID: 1561
		MessageIdCreateVideoProcessorInputViewInvalidArray,
		// Token: 0x0400061A RID: 1562
		MessageIdCreateVideoProcessorInputViewInvalidDimension,
		// Token: 0x0400061B RID: 1563
		MessageIdCreateVideoProcessorOutputViewOufOfMemoryReturn,
		// Token: 0x0400061C RID: 1564
		MessageIdCreateVideoProcessorOutputViewNullParam,
		// Token: 0x0400061D RID: 1565
		MessageIdCreateVideoProcessorOutputViewInvalidType,
		// Token: 0x0400061E RID: 1566
		MessageIdCreateVideoProcessorOutputViewInvalidBind,
		// Token: 0x0400061F RID: 1567
		MessageIdCreateVideoProcessorOutputViewInvalidFormat,
		// Token: 0x04000620 RID: 1568
		MessageIdCreateVideoProcessorOutputViewInvalidMip,
		// Token: 0x04000621 RID: 1569
		MessageIdCreateVideoProcessorOutputViewUnsupportedMip,
		// Token: 0x04000622 RID: 1570
		MessageIdCreateVideoProcessorOutputViewUnsupportedArray,
		// Token: 0x04000623 RID: 1571
		MessageIdCreateVideoProcessorOutputViewInvalidArray,
		// Token: 0x04000624 RID: 1572
		MessageIdCreateVideoProcessorOutputViewInvalidDimension,
		// Token: 0x04000625 RID: 1573
		MessageIdDeviceDrawInvalidUseOfForcedSampleCount,
		// Token: 0x04000626 RID: 1574
		MessageIdCreateBlendStateInvalidLogicOperations,
		// Token: 0x04000627 RID: 1575
		MessageIdCreateShaderResourceViewInvalidDarraywithdecoder,
		// Token: 0x04000628 RID: 1576
		MessageIdCreateUnorderedAccessViewInvalidDarraywithdecoder,
		// Token: 0x04000629 RID: 1577
		MessageIdCreateRenderTargetViewInvalidDarraywithdecoder,
		// Token: 0x0400062A RID: 1578
		MessageIdDeviceLockedoutInterface,
		// Token: 0x0400062B RID: 1579
		MessageIdRefWarningAtomicInconsistent,
		// Token: 0x0400062C RID: 1580
		MessageIdRefWarningReadingUninitializedResource,
		// Token: 0x0400062D RID: 1581
		MessageIdRefWarningRawHazard,
		// Token: 0x0400062E RID: 1582
		MessageIdRefWarningWarHazard,
		// Token: 0x0400062F RID: 1583
		MessageIdRefWarningWawHazard,
		// Token: 0x04000630 RID: 1584
		MessageIdCreateCryptosessionNullParam,
		// Token: 0x04000631 RID: 1585
		MessageIdCreateCryptosessionOufOfMemoryReturn,
		// Token: 0x04000632 RID: 1586
		MessageIdGetCryptotypeNullParam,
		// Token: 0x04000633 RID: 1587
		MessageIdGetDecoderprofileNullParam,
		// Token: 0x04000634 RID: 1588
		MessageIdGetCryptoSessionCertificateSizeNullParam,
		// Token: 0x04000635 RID: 1589
		MessageIdGetCryptoSessionCertificateNullParam,
		// Token: 0x04000636 RID: 1590
		MessageIdGetCryptoSessionCertificateWrongSize,
		// Token: 0x04000637 RID: 1591
		MessageIdGetCryptoSessionHandleWrongSize,
		// Token: 0x04000638 RID: 1592
		MessageIdNegotiatecrpytosessionkeyexchangeNullParam,
		// Token: 0x04000639 RID: 1593
		MessageIdEncryptionBlitUnsupported,
		// Token: 0x0400063A RID: 1594
		MessageIdEncryptionBlitNullParam,
		// Token: 0x0400063B RID: 1595
		MessageIdEncryptionBlitSourceWrongDevice,
		// Token: 0x0400063C RID: 1596
		MessageIdEncryptionBlitDestinationWrongDevice,
		// Token: 0x0400063D RID: 1597
		MessageIdEncryptionBlitFormatMismatch,
		// Token: 0x0400063E RID: 1598
		MessageIdEncryptionBlitSizeMismatch,
		// Token: 0x0400063F RID: 1599
		MessageIdEncryptionBlitSourceMultisampled,
		// Token: 0x04000640 RID: 1600
		MessageIdEncryptionBlitDestinationNotStaging,
		// Token: 0x04000641 RID: 1601
		MessageIdEncryptionBlitSourceMapped,
		// Token: 0x04000642 RID: 1602
		MessageIdEncryptionBlitDestinationMapped,
		// Token: 0x04000643 RID: 1603
		MessageIdEncryptionBlitSourceOffered,
		// Token: 0x04000644 RID: 1604
		MessageIdEncryptionBlitDestinationOffered,
		// Token: 0x04000645 RID: 1605
		MessageIdEncryptionBlitSourceContentUndefined,
		// Token: 0x04000646 RID: 1606
		MessageIdDecryptionBlitUnsupported,
		// Token: 0x04000647 RID: 1607
		MessageIdDecryptionBlitNullParam,
		// Token: 0x04000648 RID: 1608
		MessageIdDecryptionBlitSourceWrongDevice,
		// Token: 0x04000649 RID: 1609
		MessageIdDecryptionBlitDestinationWrongDevice,
		// Token: 0x0400064A RID: 1610
		MessageIdDecryptionBlitFormatMismatch,
		// Token: 0x0400064B RID: 1611
		MessageIdDecryptionBlitSizeMismatch,
		// Token: 0x0400064C RID: 1612
		MessageIdDecryptionBlitDestinationMultisampled,
		// Token: 0x0400064D RID: 1613
		MessageIdDecryptionBlitSourceNotStaging,
		// Token: 0x0400064E RID: 1614
		MessageIdDecryptionBlitDestinationNotRenderTarget,
		// Token: 0x0400064F RID: 1615
		MessageIdDecryptionBlitSourceMapped,
		// Token: 0x04000650 RID: 1616
		MessageIdDecryptionBlitDestinationMapped,
		// Token: 0x04000651 RID: 1617
		MessageIdDecryptionBlitSourceOffered,
		// Token: 0x04000652 RID: 1618
		MessageIdDecryptionBlitDestinationOffered,
		// Token: 0x04000653 RID: 1619
		MessageIdDecryptionBlitSourceContentUndefined,
		// Token: 0x04000654 RID: 1620
		MessageIdStartsessionkeyrefreshNullParam,
		// Token: 0x04000655 RID: 1621
		MessageIdStartsessionkeyrefreshInvalidSize,
		// Token: 0x04000656 RID: 1622
		MessageIdFinishSessionkeyrefreshNullParam,
		// Token: 0x04000657 RID: 1623
		MessageIdGetEncryptionBlitKeyNullParam,
		// Token: 0x04000658 RID: 1624
		MessageIdGetEncryptionBlitKeyInvalidSize,
		// Token: 0x04000659 RID: 1625
		MessageIdGetContentprotectioncapsNullParam,
		// Token: 0x0400065A RID: 1626
		MessageIdCheckCryptokeyexchangeNullParam,
		// Token: 0x0400065B RID: 1627
		MessageIdCheckCryptokeyexchangeInvalidIndex,
		// Token: 0x0400065C RID: 1628
		MessageIdCreateAuthenticatedChannelNullParam,
		// Token: 0x0400065D RID: 1629
		MessageIdCreateAuthenticatedChannelUnsupported,
		// Token: 0x0400065E RID: 1630
		MessageIdCreateAuthenticatedChannelInvalidType,
		// Token: 0x0400065F RID: 1631
		MessageIdCreateAuthenticatedChannelOufOfMemoryReturn,
		// Token: 0x04000660 RID: 1632
		MessageIdGetAuthenticatedChannelcertificatesizeInvalidChannel,
		// Token: 0x04000661 RID: 1633
		MessageIdGetAuthenticatedChannelcertificatesizeNullParam,
		// Token: 0x04000662 RID: 1634
		MessageIdGetAuthenticatedChannelcertificateInvalidChannel,
		// Token: 0x04000663 RID: 1635
		MessageIdGetAuthenticatedChannelcertificateNullParam,
		// Token: 0x04000664 RID: 1636
		MessageIdGetAuthenticatedChannelcertificateWrongSize,
		// Token: 0x04000665 RID: 1637
		MessageIdNegotiateauthenticatedchannelkeyexchangeInvalidChannel,
		// Token: 0x04000666 RID: 1638
		MessageIdNegotiateauthenticatedchannelkeyexchangeNullParam,
		// Token: 0x04000667 RID: 1639
		MessageIdQueryAuthenticatedChannelNullParam,
		// Token: 0x04000668 RID: 1640
		MessageIdQueryAuthenticatedChannelWrongChannel,
		// Token: 0x04000669 RID: 1641
		MessageIdQueryAuthenticatedChannelUnsupportedQuery,
		// Token: 0x0400066A RID: 1642
		MessageIdQueryAuthenticatedChannelWrongSize,
		// Token: 0x0400066B RID: 1643
		MessageIdQueryAuthenticatedChannelInvalidProcessindex,
		// Token: 0x0400066C RID: 1644
		MessageIdConfigureauthenticatedchannelNullParam,
		// Token: 0x0400066D RID: 1645
		MessageIdConfigureauthenticatedchannelWrongChannel,
		// Token: 0x0400066E RID: 1646
		MessageIdConfigureauthenticatedchannelUnsupportedConfigure,
		// Token: 0x0400066F RID: 1647
		MessageIdConfigureauthenticatedchannelWrongSize,
		// Token: 0x04000670 RID: 1648
		MessageIdConfigureauthenticatedchannelInvalidProcessidtype,
		// Token: 0x04000671 RID: 1649
		MessageIdVertexShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000672 RID: 1650
		MessageIdDomainShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000673 RID: 1651
		MessageIdHullShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000674 RID: 1652
		MessageIdGeometryShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000675 RID: 1653
		MessageIdPixelShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000676 RID: 1654
		MessageIdComputeShaderSetConstantBuffersInvalidBufferOffsetorcount,
		// Token: 0x04000677 RID: 1655
		MessageIdNegotiatecrpytosessionkeyexchangeInvalidSize,
		// Token: 0x04000678 RID: 1656
		MessageIdNegotiateauthenticatedchannelkeyexchangeInvalidSize,
		// Token: 0x04000679 RID: 1657
		MessageIdOfferresourcesInvalidPriority,
		// Token: 0x0400067A RID: 1658
		MessageIdGetCryptoSessionHandleOufOfMemory,
		// Token: 0x0400067B RID: 1659
		MessageIdAcquirehandleforcaptureNullParam,
		// Token: 0x0400067C RID: 1660
		MessageIdAcquirehandleforcaptureInvalidType,
		// Token: 0x0400067D RID: 1661
		MessageIdAcquirehandleforcaptureInvalidBind,
		// Token: 0x0400067E RID: 1662
		MessageIdAcquirehandleforcaptureInvalidArray,
		// Token: 0x0400067F RID: 1663
		MessageIdVideoProcessorSetStreamRotationNullParam,
		// Token: 0x04000680 RID: 1664
		MessageIdVideoProcessorSetStreamRotationInvalidStream,
		// Token: 0x04000681 RID: 1665
		MessageIdVideoProcessorSetStreamRotationInvalid,
		// Token: 0x04000682 RID: 1666
		MessageIdVideoProcessorSetStreamRotationUnsupported,
		// Token: 0x04000683 RID: 1667
		MessageIdVideoProcessorGetStreamRotationNullParam,
		// Token: 0x04000684 RID: 1668
		MessageIdDeviceClearviewInvalidView,
		// Token: 0x04000685 RID: 1669
		MessageIdDeviceCreateVertexShaderDoubleExtensionSnotsupported,
		// Token: 0x04000686 RID: 1670
		MessageIdDeviceCreateVertexShaderShaderExtensionSnotsupported,
		// Token: 0x04000687 RID: 1671
		MessageIdDeviceCreateHullShaderDoubleExtensionSnotsupported,
		// Token: 0x04000688 RID: 1672
		MessageIdDeviceCreateHullShaderShaderExtensionSnotsupported,
		// Token: 0x04000689 RID: 1673
		MessageIdDeviceCreateDomainShaderDoubleExtensionSnotsupported,
		// Token: 0x0400068A RID: 1674
		MessageIdDeviceCreateDomainShaderShaderExtensionSnotsupported,
		// Token: 0x0400068B RID: 1675
		MessageIdDeviceCreateGeometryShaderDoubleExtensionSnotsupported,
		// Token: 0x0400068C RID: 1676
		MessageIdDeviceCreateGeometryShaderShaderExtensionSnotsupported,
		// Token: 0x0400068D RID: 1677
		MessageIdDeviceCreateGeometryShaderWithStreamOutputDoubleExtensionSnotsupported,
		// Token: 0x0400068E RID: 1678
		MessageIdDeviceCreateGeometryShaderWithStreamOutputShaderExtensionSnotsupported,
		// Token: 0x0400068F RID: 1679
		MessageIdDeviceCreatePixelShaderDoubleExtensionSnotsupported,
		// Token: 0x04000690 RID: 1680
		MessageIdDeviceCreatePixelShaderShaderExtensionSnotsupported,
		// Token: 0x04000691 RID: 1681
		MessageIdDeviceCreateComputeShaderDoubleExtensionSnotsupported,
		// Token: 0x04000692 RID: 1682
		MessageIdDeviceCreateComputeShaderShaderExtensionSnotsupported,
		// Token: 0x04000693 RID: 1683
		MessageIdDeviceShaderLinkageMinimumPrecision,
		// Token: 0x04000694 RID: 1684
		MessageIdVideoProcessorSetStreamAlphaUnsupported,
		// Token: 0x04000695 RID: 1685
		MessageIdVideoProcessorSetStreamPixelAspectRatioUnsupported,
		// Token: 0x04000696 RID: 1686
		MessageIdDeviceCreateVertexShaderUnorderedAccessViewsNotSupported,
		// Token: 0x04000697 RID: 1687
		MessageIdDeviceCreateHullShaderUnorderedAccessViewsNotSupported,
		// Token: 0x04000698 RID: 1688
		MessageIdDeviceCreateDomainShaderUnorderedAccessViewsNotSupported,
		// Token: 0x04000699 RID: 1689
		MessageIdDeviceCreateGeometryShaderUnorderedAccessViewsNotSupported,
		// Token: 0x0400069A RID: 1690
		MessageIdDeviceCreateGeometryShaderWithStreamOutputUnorderedAccessViewsNotSupported,
		// Token: 0x0400069B RID: 1691
		MessageIdDeviceCreatePixelShaderUnorderedAccessViewsNotSupported,
		// Token: 0x0400069C RID: 1692
		MessageIdDeviceCreateComputeShaderUnorderedAccessViewsNotSupported,
		// Token: 0x0400069D RID: 1693
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsInvalidOffset,
		// Token: 0x0400069E RID: 1694
		MessageIdDeviceOutputMergerSetRenderTargetsAndUnorderedAccessViewsTooManyViews,
		// Token: 0x0400069F RID: 1695
		MessageIdDeviceClearviewNotSupported,
		// Token: 0x040006A0 RID: 1696
		MessageIdSwapdevicecontextstateNotSupported,
		// Token: 0x040006A1 RID: 1697
		MessageIdUpdatesUbresourcePreferUpdatesUbresource1,
		// Token: 0x040006A2 RID: 1698
		MessageIdGetDeviceContextInaccessible,
		// Token: 0x040006A3 RID: 1699
		MessageIdDeviceClearviewInvalidRectangle,
		// Token: 0x040006A4 RID: 1700
		MessageIdDeviceDrawSampleMaskIgnoredOnFl9,
		// Token: 0x040006A5 RID: 1701
		MessageIdDeviceOpenSharedResource1NotSupported,
		// Token: 0x040006A6 RID: 1702
		MessageIdDeviceOpenSharedResourceByNameNotSupported,
		// Token: 0x040006A7 RID: 1703
		MessageIdEnqueueSetEventNotSupported,
		// Token: 0x040006A8 RID: 1704
		MessageIdOfferreleaseNotSupported,
		// Token: 0x040006A9 RID: 1705
		MessageIdOfferresourcesInaccessible,
		// Token: 0x040006AA RID: 1706
		MessageIdCreateVideoProcessorInputViewInvalidMSAA,
		// Token: 0x040006AB RID: 1707
		MessageIdCreateVideoProcessorOutputViewInvalidMSAA,
		// Token: 0x040006AC RID: 1708
		MessageIdDeviceClearviewInvalidSourceRectangle,
		// Token: 0x040006AD RID: 1709
		MessageIdDeviceClearviewEmptyRectangle,
		// Token: 0x040006AE RID: 1710
		MessageIdUpdatesUbresourceEmptyDestinationBox,
		// Token: 0x040006AF RID: 1711
		MessageIdCopySubResourceRegionEmptySourceBox,
		// Token: 0x040006B0 RID: 1712
		MessageIdDeviceDrawOutputMergerRenderTargetDoesNotSupportLogicOperations,
		// Token: 0x040006B1 RID: 1713
		MessageIdDeviceDrawDepthStencilViewNotSet,
		// Token: 0x040006B2 RID: 1714
		MessageIdDeviceDrawRenderTargetViewNotSet,
		// Token: 0x040006B3 RID: 1715
		MessageIdDeviceDrawRenderTargetViewNotSetDueToFlipPresent,
		// Token: 0x040006B4 RID: 1716
		MessageIdDeviceUnorderedAccessViewNotSetDueToFlipPresent,
		// Token: 0x040006B5 RID: 1717
		MessageIdGetDataFornewhardwarekeyNullParam,
		// Token: 0x040006B6 RID: 1718
		MessageIdCheckCryptosessionstatusNullParam,
		// Token: 0x040006B7 RID: 1719
		MessageIdGetCryptoSessionPrivateDataSizeNullParam,
		// Token: 0x040006B8 RID: 1720
		MessageIdGetVideoDecodercapsNullParam,
		// Token: 0x040006B9 RID: 1721
		MessageIdGetVideoDecodercapsZerowidthheight,
		// Token: 0x040006BA RID: 1722
		MessageIdCheckVideoDecoderdownsamplingNullParam,
		// Token: 0x040006BB RID: 1723
		MessageIdCheckVideoDecoderdownsamplingInvalidColorSpace,
		// Token: 0x040006BC RID: 1724
		MessageIdCheckVideoDecoderdownsamplingZerowidthheight,
		// Token: 0x040006BD RID: 1725
		MessageIdVideoDecoderenabledownsamplingNullParam,
		// Token: 0x040006BE RID: 1726
		MessageIdVideoDecoderenabledownsamplingUnsupported,
		// Token: 0x040006BF RID: 1727
		MessageIdVideoDecoderupdatedownsamplingNullParam,
		// Token: 0x040006C0 RID: 1728
		MessageIdVideoDecoderupdatedownsamplingUnsupported,
		// Token: 0x040006C1 RID: 1729
		MessageIdCheckVideoProcessorFormatConversionNullParam,
		// Token: 0x040006C2 RID: 1730
		MessageIdVideoProcessorSetOutputColorSpace1NullParam,
		// Token: 0x040006C3 RID: 1731
		MessageIdVideoProcessorGetOutputColorSpace1NullParam,
		// Token: 0x040006C4 RID: 1732
		MessageIdVideoProcessorSetStreamColorSpace1NullParam,
		// Token: 0x040006C5 RID: 1733
		MessageIdVideoProcessorSetStreamColorSpace1InvalidStream,
		// Token: 0x040006C6 RID: 1734
		MessageIdVideoProcessorSetStreamMirrorNullParam,
		// Token: 0x040006C7 RID: 1735
		MessageIdVideoProcessorSetStreamMirrorInvalidStream,
		// Token: 0x040006C8 RID: 1736
		MessageIdVideoProcessorSetStreamMirrorUnsupported,
		// Token: 0x040006C9 RID: 1737
		MessageIdVideoProcessorGetStreamColorSpace1NullParam,
		// Token: 0x040006CA RID: 1738
		MessageIdVideoProcessorGetStreamMirrorNullParam,
		// Token: 0x040006CB RID: 1739
		MessageIdRecommendvideodecoderdownsamplingNullParam,
		// Token: 0x040006CC RID: 1740
		MessageIdRecommendvideodecoderdownsamplingInvalidColorSpace,
		// Token: 0x040006CD RID: 1741
		MessageIdRecommendvideodecoderdownsamplingZerowidthheight,
		// Token: 0x040006CE RID: 1742
		MessageIdVideoProcessorSetOutputShaderUsageNullParam,
		// Token: 0x040006CF RID: 1743
		MessageIdVideoProcessorGetOutputShaderUsageNullParam,
		// Token: 0x040006D0 RID: 1744
		MessageIdVideoProcessorGetBehaviorhintsNullParam,
		// Token: 0x040006D1 RID: 1745
		MessageIdVideoProcessorGetBehaviorhintsInvalidStreamCount,
		// Token: 0x040006D2 RID: 1746
		MessageIdVideoProcessorGetBehaviorhintsTargetRectangle,
		// Token: 0x040006D3 RID: 1747
		MessageIdVideoProcessorGetBehaviorhintsInvalidSourceRectangle,
		// Token: 0x040006D4 RID: 1748
		MessageIdVideoProcessorGetBehaviorhintsInvalidDestinationRectangle,
		// Token: 0x040006D5 RID: 1749
		MessageIdGetCryptoSessionPrivateDataSizeInvalidKeyExchangeType,
		// Token: 0x040006D6 RID: 1750
		MessageIdD3D111MessagesEnd,
		// Token: 0x040006D7 RID: 1751
		MessageIdD3D112MessagesStart,
		// Token: 0x040006D8 RID: 1752
		MessageIdCreateBufferInvalidUsage,
		// Token: 0x040006D9 RID: 1753
		MessageIdCreateTexture1DInvalidUsage,
		// Token: 0x040006DA RID: 1754
		MessageIdCreateTexture2DInvalidUsage,
		// Token: 0x040006DB RID: 1755
		MessageIdCreateInputLayoutLevel9SteprateNot1,
		// Token: 0x040006DC RID: 1756
		MessageIdCreateInputLayoutLevel9InstancingNotSupported,
		// Token: 0x040006DD RID: 1757
		MessageIdUpdateTilemappingsInvalidParameter,
		// Token: 0x040006DE RID: 1758
		MessageIdCopyTilemappingsInvalidParameter,
		// Token: 0x040006DF RID: 1759
		MessageIdCopyTilesInvalidParameter,
		// Token: 0x040006E0 RID: 1760
		MessageIdUpdateTilesInvalidParameter,
		// Token: 0x040006E1 RID: 1761
		MessageIdResizetilepoolInvalidParameter,
		// Token: 0x040006E2 RID: 1762
		MessageIdTiledresourcebarrierInvalidParameter,
		// Token: 0x040006E3 RID: 1763
		MessageIdNullTileMappingAccessWarning,
		// Token: 0x040006E4 RID: 1764
		MessageIdNullTileMappingAccessError,
		// Token: 0x040006E5 RID: 1765
		MessageIdDirtyTileMappingAccess,
		// Token: 0x040006E6 RID: 1766
		MessageIdDuplicateTileMappingsInCoveredArea,
		// Token: 0x040006E7 RID: 1767
		MessageIdTileMappingsInCoveredAreaDuplicatedOutside,
		// Token: 0x040006E8 RID: 1768
		MessageIdTileMappingsSharedBetweenIncompatibleResources,
		// Token: 0x040006E9 RID: 1769
		MessageIdTileMappingsSharedBetweenInputAndOutput,
		// Token: 0x040006EA RID: 1770
		MessageIdCheckMultisamplequalitylevelsInvalidFlags,
		// Token: 0x040006EB RID: 1771
		MessageIdGetResourceTilingNontiledResource,
		// Token: 0x040006EC RID: 1772
		MessageIdResizetilepoolShrinkWithMappingsStillDefinedPastEnd,
		// Token: 0x040006ED RID: 1773
		MessageIdNeedToCallTiledresourcebarrier,
		// Token: 0x040006EE RID: 1774
		MessageIdCreateDeviceInvalidArguments,
		// Token: 0x040006EF RID: 1775
		MessageIdCreateDeviceWarning,
		// Token: 0x040006F0 RID: 1776
		MessageIdClearunorderedaccessviewuintHazard,
		// Token: 0x040006F1 RID: 1777
		MessageIdClearunorderedaccessviewfloatHazard,
		// Token: 0x040006F2 RID: 1778
		MessageIdTiledResourceTier1BufferTextureMismatch,
		// Token: 0x040006F3 RID: 1779
		MessageIdCreateCryptosession,
		// Token: 0x040006F4 RID: 1780
		MessageIdCreateAuthenticatedChannel,
		// Token: 0x040006F5 RID: 1781
		MessageIdLiveCryptosession,
		// Token: 0x040006F6 RID: 1782
		MessageIdLiveAuthenticatedChannel,
		// Token: 0x040006F7 RID: 1783
		MessageIdDestroyCryptosession,
		// Token: 0x040006F8 RID: 1784
		MessageIdDestroyAuthenticatedChannel,
		// Token: 0x040006F9 RID: 1785
		MessageIdD3D112MessagesEnd,
		// Token: 0x040006FA RID: 1786
		MessageIdD3D113MessagesStart,
		// Token: 0x040006FB RID: 1787
		MessageIdCreateRasterizerstateInvalidConservativerastermode,
		// Token: 0x040006FC RID: 1788
		MessageIdDeviceDrawInvalidSystemvalue,
		// Token: 0x040006FD RID: 1789
		MessageIdCreateQueryOrpredicateInvalidContextType,
		// Token: 0x040006FE RID: 1790
		MessageIdCreateQueryOrpredicateDecodenotsupported,
		// Token: 0x040006FF RID: 1791
		MessageIdCreateQueryOrpredicateEncodenotsupported,
		// Token: 0x04000700 RID: 1792
		MessageIdCreateShaderResourceViewInvalidPlaneindex,
		// Token: 0x04000701 RID: 1793
		MessageIdCreateShaderResourceViewInvalidVideoPlaneindex,
		// Token: 0x04000702 RID: 1794
		MessageIdCreateShaderResourceViewAmbiguousvideoplaneindex,
		// Token: 0x04000703 RID: 1795
		MessageIdCreateRenderTargetViewInvalidPlaneindex,
		// Token: 0x04000704 RID: 1796
		MessageIdCreateRenderTargetViewInvalidVideoPlaneindex,
		// Token: 0x04000705 RID: 1797
		MessageIdCreateRenderTargetViewAmbiguousvideoplaneindex,
		// Token: 0x04000706 RID: 1798
		MessageIdCreateUnorderedAccessViewInvalidPlaneindex,
		// Token: 0x04000707 RID: 1799
		MessageIdCreateUnorderedAccessViewInvalidVideoPlaneindex,
		// Token: 0x04000708 RID: 1800
		MessageIdCreateUnorderedAccessViewAmbiguousvideoplaneindex,
		// Token: 0x04000709 RID: 1801
		MessageIdJpegdecodeInvalidScandataoffset,
		// Token: 0x0400070A RID: 1802
		MessageIdJpegdecodeNotSupported,
		// Token: 0x0400070B RID: 1803
		MessageIdJpegdecodeDimensionstoolarge,
		// Token: 0x0400070C RID: 1804
		MessageIdJpegdecodeInvalidComponents,
		// Token: 0x0400070D RID: 1805
		MessageIdJpegdecodeDestinationNot2D,
		// Token: 0x0400070E RID: 1806
		MessageIdJpegdecodeTiledresourcesunsupported,
		// Token: 0x0400070F RID: 1807
		MessageIdJpegdecodeGuardrectsunsupported,
		// Token: 0x04000710 RID: 1808
		MessageIdJpegdecodeFormatUnsupported,
		// Token: 0x04000711 RID: 1809
		MessageIdJpegdecodeInvalidSubResource,
		// Token: 0x04000712 RID: 1810
		MessageIdJpegdecodeInvalidMiplevel,
		// Token: 0x04000713 RID: 1811
		MessageIdJpegdecodeEmptyDestinationBox,
		// Token: 0x04000714 RID: 1812
		MessageIdJpegdecodeDestinationBoxnot2d,
		// Token: 0x04000715 RID: 1813
		MessageIdJpegdecodeDestinationBoxnotsub,
		// Token: 0x04000716 RID: 1814
		MessageIdJpegdecodeDestinationBoxesintersect,
		// Token: 0x04000717 RID: 1815
		MessageIdJpegdecodeXsubsamplemismatch,
		// Token: 0x04000718 RID: 1816
		MessageIdJpegdecodeYsubsamplemismatch,
		// Token: 0x04000719 RID: 1817
		MessageIdJpegdecodeXsubsampleodd,
		// Token: 0x0400071A RID: 1818
		MessageIdJpegdecodeYsubsampleodd,
		// Token: 0x0400071B RID: 1819
		MessageIdJpegdecodeOutputDimensionstoolarge,
		// Token: 0x0400071C RID: 1820
		MessageIdJpegdecodeNonpow2scaleunsupported,
		// Token: 0x0400071D RID: 1821
		MessageIdJpegdecodeFractionaldownscaletolarge,
		// Token: 0x0400071E RID: 1822
		MessageIdJpegdecodeChromasizemismatch,
		// Token: 0x0400071F RID: 1823
		MessageIdJpegdecodeLumachromasizemismatch,
		// Token: 0x04000720 RID: 1824
		MessageIdJpegdecodeInvalidNumdestinations,
		// Token: 0x04000721 RID: 1825
		MessageIdJpegdecodeSubBoxunsupported,
		// Token: 0x04000722 RID: 1826
		MessageIdJpegdecode1DEstunsupportedformat,
		// Token: 0x04000723 RID: 1827
		MessageIdJpegdecode3DEstunsupportedformat,
		// Token: 0x04000724 RID: 1828
		MessageIdJpegdecodeScaleunsupported,
		// Token: 0x04000725 RID: 1829
		MessageIdJpegdecodeInvalidSourceSize,
		// Token: 0x04000726 RID: 1830
		MessageIdJpegdecodeInvalidCopyFlags,
		// Token: 0x04000727 RID: 1831
		MessageIdJpegdecodeHazard,
		// Token: 0x04000728 RID: 1832
		MessageIdJpegdecodeUnsupportedSourceBufferUsage,
		// Token: 0x04000729 RID: 1833
		MessageIdJpegdecodeUnsupportedSourceBufferMiscFlags,
		// Token: 0x0400072A RID: 1834
		MessageIdJpegdecodeUnsupportedDestinationTextureUsage,
		// Token: 0x0400072B RID: 1835
		MessageIdJpegdecodeBackbuffernotsupported,
		// Token: 0x0400072C RID: 1836
		MessageIdJpegdecodeUnsupprtedcopyflags,
		// Token: 0x0400072D RID: 1837
		MessageIdJpegencodeNotSupported,
		// Token: 0x0400072E RID: 1838
		MessageIdJpegencodeInvalidScandataoffset,
		// Token: 0x0400072F RID: 1839
		MessageIdJpegencodeInvalidComponents,
		// Token: 0x04000730 RID: 1840
		MessageIdJpegencodeSourceNot2D,
		// Token: 0x04000731 RID: 1841
		MessageIdJpegencodeTiledresourcesunsupported,
		// Token: 0x04000732 RID: 1842
		MessageIdJpegencodeGuardrectsunsupported,
		// Token: 0x04000733 RID: 1843
		MessageIdJpegencodeXsubsamplemismatch,
		// Token: 0x04000734 RID: 1844
		MessageIdJpegencodeYsubsamplemismatch,
		// Token: 0x04000735 RID: 1845
		MessageIdJpegencodeFormatUnsupported,
		// Token: 0x04000736 RID: 1846
		MessageIdJpegencodeInvalidSubResource,
		// Token: 0x04000737 RID: 1847
		MessageIdJpegencodeInvalidMiplevel,
		// Token: 0x04000738 RID: 1848
		MessageIdJpegencodeDimensionstoolarge,
		// Token: 0x04000739 RID: 1849
		MessageIdJpegencodeHazard,
		// Token: 0x0400073A RID: 1850
		MessageIdJpegencodeUnsupportedDestinationBufferUsage,
		// Token: 0x0400073B RID: 1851
		MessageIdJpegencodeUnsupportedDestinationBufferMiscFlags,
		// Token: 0x0400073C RID: 1852
		MessageIdJpegencodeUnsupportedSourceTextureUsage,
		// Token: 0x0400073D RID: 1853
		MessageIdJpegencodeBackbuffernotsupported,
		// Token: 0x0400073E RID: 1854
		MessageIdCreateQueryOrpredicateUnsupportedContextTtypeforquery,
		// Token: 0x0400073F RID: 1855
		MessageIdFlush1InvalidContextType,
		// Token: 0x04000740 RID: 1856
		MessageIdDeviceSetHardwareprotectionInvalidContext,
		// Token: 0x04000741 RID: 1857
		MessageIdVideoProcessorSetOutputHdrmetadataNullParam,
		// Token: 0x04000742 RID: 1858
		MessageIdVideoProcessorSetOutputHdrmetadataInvalidSize,
		// Token: 0x04000743 RID: 1859
		MessageIdVideoProcessorGetOutputHdrmetadataNullParam,
		// Token: 0x04000744 RID: 1860
		MessageIdVideoProcessorGetOutputHdrmetadataInvalidSize,
		// Token: 0x04000745 RID: 1861
		MessageIdVideoProcessorSetStreamHdrmetadataNullParam,
		// Token: 0x04000746 RID: 1862
		MessageIdVideoProcessorSetStreamHdrmetadataInvalidStream,
		// Token: 0x04000747 RID: 1863
		MessageIdVideoProcessorSetStreamHdrmetadataInvalidSize,
		// Token: 0x04000748 RID: 1864
		MessageIdVideoProcessorGetStreamHdrmetadataNullParam,
		// Token: 0x04000749 RID: 1865
		MessageIdVideoProcessorGetStreamHdrmetadataInvalidStream,
		// Token: 0x0400074A RID: 1866
		MessageIdVideoProcessorGetStreamHdrmetadataInvalidSize,
		// Token: 0x0400074B RID: 1867
		MessageIdVideoProcessorGetStreamFrameFormatInvalidStream,
		// Token: 0x0400074C RID: 1868
		MessageIdVideoProcessorGetStreamColorSpaceInvalidStream,
		// Token: 0x0400074D RID: 1869
		MessageIdVideoProcessorGetStreamOutputRateInvalidStream,
		// Token: 0x0400074E RID: 1870
		MessageIdVideoProcessorGetStreamSourceRectangleInvalidStream,
		// Token: 0x0400074F RID: 1871
		MessageIdVideoProcessorGetStreamDestinationRectangleInvalidStream,
		// Token: 0x04000750 RID: 1872
		MessageIdVideoProcessorGetStreamAlphaInvalidStream,
		// Token: 0x04000751 RID: 1873
		MessageIdVideoProcessorGetStreamPaletteInvalidStream,
		// Token: 0x04000752 RID: 1874
		MessageIdVideoProcessorGetStreamPixelAspectRatioInvalidStream,
		// Token: 0x04000753 RID: 1875
		MessageIdVideoProcessorGetStreamLumakeyInvalidStream,
		// Token: 0x04000754 RID: 1876
		MessageIdVideoProcessorGetStreamStereoFormatInvalidStream,
		// Token: 0x04000755 RID: 1877
		MessageIdVideoProcessorGetStreamAutoprocessingmodeInvalidStream,
		// Token: 0x04000756 RID: 1878
		MessageIdVideoProcessorGetStreamFilterInvalidStream,
		// Token: 0x04000757 RID: 1879
		MessageIdVideoProcessorGetStreamRotationInvalidStream,
		// Token: 0x04000758 RID: 1880
		MessageIdVideoProcessorGetStreamColorSpace1InvalidStream,
		// Token: 0x04000759 RID: 1881
		MessageIdVideoProcessorGetStreamMirrorInvalidStream,
		// Token: 0x0400075A RID: 1882
		MessageIdCreateFence,
		// Token: 0x0400075B RID: 1883
		MessageIdLiveFence,
		// Token: 0x0400075C RID: 1884
		MessageIdDestroyFence,
		// Token: 0x0400075D RID: 1885
		MessageIdD3D113MessagesEnd
	}
}
