import request from "superagent";

/** @typedef {{ userId: number;dln: string;tfn: string;salary: string;religion: string;politicalParty: string; }} Sensitive*/

export class SensitiveClient {
    /**
     * @param {string} url 
     * @param {string} jwt 
     */
    constructor(url, jwt) {
        this.path = `${url}/sensitive`
        this.jwt = jwt;
    }

    /** @returns {Promise<Sensitive>} */
    async get() {
        try {
            const resp = await request.get(this.path).set("Authorization", this.jwt)
                .ok(res => res.ok || res.status === 404);

            if (resp.status === 404)
                return null;

            return resp.body;
        } catch (error) {
            console.log(error);
        }
    }

    /**
     * @param {Sensitive} data
     * @returns {Promise}
     **/
    async update(data) {
        try {
            await request.post(this.path).set("Authorization", this.jwt).send(data);
        } catch (error) {
            console.log(error);
        }
    }
}
