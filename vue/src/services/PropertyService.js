import axios from 'axios';

export default {

    getAllProperties() {
        return axios.get('/properties');
    },
    getAllMyProperties() {
        return axios.get('/properties/myproperties');
    },
    addProperty(property) {
         return axios.post('/properties', property);
    },
    searchProperties(zipcode,beds,baths){
        return axios.get('/search',zipcode, beds,baths);
    }
}