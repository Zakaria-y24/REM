import axios from 'axios';

export default {

    getAllProperties() {
        return axios.get('/properties');
    },
    addNewProperties() {
         axios.post('/addProperties');
    }

}