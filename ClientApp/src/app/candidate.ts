export interface Candidate {
    id: number,
    email: string,
    firstName: string,
    lastName: string ,
    phoneNumber: string | undefined,
    startCallTimeInterval: Date | undefined,
    endCallTimeInterval: Date | undefined,
    linkedInProfile: string | undefined,
    githubProfile: string | undefined,
    comment: string
}