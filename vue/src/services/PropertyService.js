import axios from 'axios';

export default {

    getAllProperties() {
        return axios.get('/properties');
    },
    addProperty(property) {
         return axios.post('/properties', property);
    },
    searchProperty(){
        return axios.get('/search');
    }
}