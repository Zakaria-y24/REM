import axios from 'axios';

export default {
    submitApplication(application) {
        return axios.post('/application', application);
    },
    ApproveApplication(application){
        return axios.put('/application/accept', application);
    },
    DenyApplication(application){
        return axios.put('/application/deny', application);
    },
    getMyApplications() {
        return axios.get('/application');
    },
    getApplicationsForOwner() {
        return axios.get('/application/properties');
    },
}