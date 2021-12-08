import axios from 'axios';

export default {
    sumitApplication(application) {
        return axios.post('/application', application);
    }
}