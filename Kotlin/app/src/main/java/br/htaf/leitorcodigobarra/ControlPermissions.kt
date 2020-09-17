package br.htaf.leitorcodigobarra

import android.Manifest
import androidx.appcompat.app.AppCompatActivity
import pub.devrel.easypermissions.EasyPermissions
import pub.devrel.easypermissions.PermissionRequest

open class ControlPermissions: AppCompatActivity(), EasyPermissions.PermissionCallbacks {
    val REQUEST_CODE_CAMERA = 182 /* O INTEIRO DEFINIDO AQUI É ALEATÓRIO */

    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<String>,
        grantResults: IntArray ) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults)

        /* Encaminhando resultados para EasyPermissions API */
        EasyPermissions.onRequestPermissionsResult(
            requestCode,
            permissions,
            grantResults,
            this )
    }

    override fun onPermissionsDenied(
        requestCode: Int,
        perms: MutableList<String>) {

        /* TODO */
    }

    protected fun askCameraPermission(){
        EasyPermissions.requestPermissions(
            PermissionRequest.Builder( this, REQUEST_CODE_CAMERA, Manifest.permission.CAMERA )
                .setRationale( "A permissão de uso de câmera é necessária para que o aplicativo funcione." )
                .setPositiveButtonText( "Ok" )
                .setNegativeButtonText( "Cancelar" )
                .build() )
    }

    override fun onPermissionsGranted(
        requestCode: Int,
        perms: MutableList<String>) {

        /* AQUI SE INICIA A EXECUÇÃO DA BARCODE SCANNER API - ABERTURA DA CÂMERA */
    }
}