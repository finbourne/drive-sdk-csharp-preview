# Finbourne.Drive.Sdk.Model.StorageObject
An object representation of a drive file or folder

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | File or folder identifier | 
**Path** | **string** | Path of the folder or file | 
**Name** | **string** | Name of the folder or file | 
**CreatedBy** | **string** | Identifier of the user who created the file or folder | 
**CreatedOn** | **DateTimeOffset** | Date of file/folder creation | 
**UpdatedBy** | **string** | Identifier of the last user to modify the file or folder | 
**UpdatedOn** | **DateTimeOffset** | Date of file/folder modification | 
**Type** | **string** | Type of storage object (file or folder) | 
**Size** | **int?** | Size of the file in bytes | [optional] 
**Status** | **string** | File status corresponding to virus scan status.  (Active, Available, Checking, MalwareDetected, Failed) | [optional] 
**StatusDetail** | **string** | Detailed description describing any negative terminal state of file | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

