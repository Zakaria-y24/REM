import axios from 'axios';

export default {
    submitApplication(application) {
        return axios.post('/application', application);
    }
}