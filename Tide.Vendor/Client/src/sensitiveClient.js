import request from "superagent";

/** @typedef {{ UserId: number; DLN: string; TFN: string; Salary: string; Religion: string; PoliticalParty: string;  }} Sensitive*/

export class SensitiveClient {
    constructor(url, jwt) {
        this.path = `${url}/tide/sensitive`
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

    /** @param {Sensitive} data */
    /** @returns {Promise} */
    async update(data) {
        try {
            await request.post(this.path).set("Authorization", this.jwt)
                .send(data).set("Authorization", this.jwt);
        } catch (error) {
            console.log(error);
        }
    }
}
