package br.htaf.myapplication;

import android.Manifest;
import android.app.Activity;
import android.content.Context;

import androidx.annotation.NonNull;

import java.util.List;

import pub.devrel.easypermissions.EasyPermissions;
import pub.devrel.easypermissions.PermissionRequest;

public class PermissionCameraCallback implements EasyPermissions.PermissionCallbacks {

    private final int REQUEST_CODE_CAMERA = 182;
    private Context context;

    public PermissionCameraCallback(Context context){
        this.context = context;
    }

    @Override
    public void onPermissionsGranted(int requestCode, @NonNull List<String> perms) {

    }

    @Override
    public void onPermissionsDenied(int requestCode, @NonNull List<String> perms) {

    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        //super (requestCode, permissions, grantResults);

            /* Encaminhando resultados para EasyPermissions API */
            EasyPermissions.onRequestPermissionsResult(
                    requestCode,
                    permissions,
                    grantResults,
                    this );
    }

    protected void askCameraPermission(){
        EasyPermissions.requestPermissions(
                new PermissionRequest.Builder((Activity) this.context, REQUEST_CODE_CAMERA , Manifest.permission.CAMERA )
                        .setRationale( "A permissão de uso de câmera é necessária para que o aplicativo funcione." )
                        .setPositiveButtonText( "Ok" )
                        .setNegativeButtonText( "Cancelar" )
                        .build());
    }
}
