package com.maybestudio.sort.sort_gcm;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        registBroadcastReceiver();

        // 토큰을 보여줄 TextView를 정의
        mInformationTextView = (TextView) findViewById(R.id.informationTextView);
        mInformationTextView.setVisibility(View.GONE);
        // 토큰을 가져오는 동안 인디케이터를 보여줄 ProgressBar를 정의
        mRegistrationProgressBar = (ProgressBar) findViewById(R.id.registrationProgressBar);
        mRegistrationProgressBar.setVisibility(ProgressBar.GONE);
        // 토큰을 가져오는 Button을 정의
        mRegistrationButton = (Button) findViewById(R.id.registrationButton);
        mRegistrationButton.setOnClickListener(new View.OnClickListener() {
            /**
             * 버튼을 클릭하면 토큰을 가져오는 getInstanceIdToken() 메소드를 실행한다.
             * @param view
             */
            @Override
            public void onClick(View view) {
                getInstanceIdToken();
            }
        });

    }

    @Override
    protected void onResume() {
        super.onResume();
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_READY));
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_GENERATING));
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_COMPLETE));

    }

    @Override
    protected void onPause() {
        LocalBroadcastManager.getInstance(this).unregisterReceiver(mRegistrationBroadcastReceiver);
        super.onPause();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }
    
    @Override
    protected void onResume() {
        super.onResume();
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_READY));
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_GENERATING));
        LocalBroadcastManager.getInstance(this).registerReceiver(mRegistrationBroadcastReceiver,
                new IntentFilter(QuickstartPreferences.REGISTRATION_COMPLETE));

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void getInstanceIdToken() {
        if (checkPlayServices()) {
            // Start IntentService to register this application with GCM.
            Intent intent = new Intent(this, RegistrationIntentService.class);
            startService(intent);
        }
    }

    @Override
    protected void onPause() {
        LocalBroadcastManager.getInstance(this).unregisterReceiver(mRegistrationBroadcastReceiver);
        super.onPause();
    }

    public void registBroadcastReceiver(){
        mRegistrationBroadcastReceiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
                String action = intent.getAction();


                if(action.equals(QuickstartPreferences.REGISTRATION_READY)){
                    // 액션이 READY일 경우
                    mRegistrationProgressBar.setVisibility(ProgressBar.GONE);
                    mInformationTextView.setVisibility(View.GONE);
                } else if(action.equals(QuickstartPreferences.REGISTRATION_GENERATING)){
                    // 액션이 GENERATING일 경우
                    mRegistrationProgressBar.setVisibility(ProgressBar.VISIBLE);
                    mInformationTextView.setVisibility(View.VISIBLE);
                    mInformationTextView.setText(getString(R.string.registering_message_generating));
                } else if(action.equals(QuickstartPreferences.REGISTRATION_COMPLETE)){
                    // 액션이 COMPLETE일 경우
                    mRegistrationProgressBar.setVisibility(ProgressBar.GONE);
                    mRegistrationButton.setText(getString(R.string.registering_message_complete));
                    mRegistrationButton.setEnabled(false);
                    String token = intent.getStringExtra("token");
                    mInformationTextView.setText(token);
                }

            }
        };
    }

    private boolean checkPlayServices() {
        int resultCode = GooglePlayServicesUtil.isGooglePlayServicesAvailable(this);
        if (resultCode != ConnectionResult.SUCCESS) {
            if (GooglePlayServicesUtil.isUserRecoverableError(resultCode)) {
                GooglePlayServicesUtil.getErrorDialog(resultCode, this,
                        PLAY_SERVICES_RESOLUTION_REQUEST).show();
            } else {
                Log.i(TAG, "This device is not supported.");
                finish();
            }
            return false;
        }
        return true;
    }
}
