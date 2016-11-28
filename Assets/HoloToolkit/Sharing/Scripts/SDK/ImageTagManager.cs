/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace HoloToolkit.Sharing {

public class ImageTagManager : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ImageTagManager(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ImageTagManager obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ImageTagManager() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_ImageTagManager(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual void Update() {
    SharingClientPINVOKE.ImageTagManager_Update(swigCPtr);
  }

  /*public unsafe bool FindTags(byte[] data, int pixelWidth, int pixelHeight, int bytesPerPixel, ImageTagLocationListener locationCallback) {
    fixed ( byte* swig_ptrTo_data = data ) {
    {
      bool ret = SharingClientPINVOKE.ImageTagManager_FindTags(swigCPtr, (global::System.IntPtr)swig_ptrTo_data, pixelWidth, pixelHeight, bytesPerPixel, ImageTagLocationListener.getCPtr(locationCallback));
      return ret;
    }
    }
  }*/

  public virtual TagImage CreateTagImage(int tagId) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ImageTagManager_CreateTagImage(swigCPtr, tagId);
    TagImage ret = (cPtr == global::System.IntPtr.Zero) ? null : new TagImage(cPtr, true);
    return ret; 
  }

  public static ImageTagManager Create() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ImageTagManager_Create();
    ImageTagManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new ImageTagManager(cPtr, true);
    return ret; 
  }

}

}
