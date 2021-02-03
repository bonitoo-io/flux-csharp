using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Api.Service;
using InfluxDB.Client.Core;
using InfluxDB.Client.Domain;

namespace InfluxDB.Client
{
    public class BucketsApi
    {
        private readonly BucketsService _service;

        protected internal BucketsApi(BucketsService service)
        {
            Arguments.CheckNotNull(service, nameof(service));

            _service = service;
        }

        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="bucket">bucket to create</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            var postBucket = new PostBucketRequest(orgID: bucket.OrgID, name: bucket.Name, description: bucket.Description,
                rp: bucket.Rp, retentionRules: bucket.RetentionRules);

            return _service.PostBucketsAsync(postBucket);
        }
        
        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="bucket">bucket to create</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(PostBucketRequest bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return _service.PostBucketsAsync(bucket);
        }

        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="name">name of the bucket</param>
        /// <param name="organization">owner of the bucket</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(string name, Organization organization)
        {
            Arguments.CheckNonEmptyString(name, nameof(name));
            Arguments.CheckNotNull(organization, nameof(organization));

            return CreateBucketAsync(name, organization.Id);
        }

        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="name">name of the bucket</param>
        /// <param name="bucketRetentionRules">retention rule of the bucket</param>
        /// <param name="organization">owner of the bucket</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(string name, BucketRetentionRules bucketRetentionRules,
            Organization organization)
        {
            Arguments.CheckNonEmptyString(name, nameof(name));
            Arguments.CheckNotNull(organization, nameof(organization));

            return CreateBucketAsync(name, bucketRetentionRules, organization.Id);
        }

        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="name">name of the bucket</param>
        /// <param name="orgId">owner of the bucket</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(string name, string orgId)
        {
            Arguments.CheckNonEmptyString(name, nameof(name));
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            return CreateBucketAsync(name, default(BucketRetentionRules), orgId);
        }

        /// <summary>
        /// Creates a new bucket and sets <see cref="Bucket.Id" /> with the new identifier.
        /// </summary>
        /// <param name="name">name of the bucket</param>
        /// <param name="bucketRetentionRules">retention rule of the bucket</param>
        /// <param name="orgId">owner of the bucket</param>
        /// <returns>created Bucket</returns>
        public Task<Bucket> CreateBucketAsync(string name, BucketRetentionRules bucketRetentionRules, string orgId)
        {
            Arguments.CheckNonEmptyString(name, nameof(name));
            Arguments.CheckNonEmptyString(orgId, nameof(orgId));

            var bucket = new Bucket(null, name, null, orgId, null, new List<BucketRetentionRules>());
            if (bucketRetentionRules != null) bucket.RetentionRules.Add(bucketRetentionRules);

            return CreateBucketAsync(bucket);
        }

        /// <summary>
        /// Update a bucket name and retention.
        /// </summary>
        /// <param name="bucket">bucket update to apply</param>
        /// <returns>bucket updated</returns>
        public Task<Bucket> UpdateBucketAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return _service.PatchBucketsIDAsync(bucket.Id, bucket);
        }

        /// <summary>
        /// Delete a bucket.
        /// </summary>
        /// <param name="bucketId">ID of bucket to delete</param>
        /// <returns>delete has been accepted</returns>
        public Task DeleteBucketAsync(string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            return _service.DeleteBucketsIDAsync(bucketId);
        }

        /// <summary>
        /// Delete a bucket.
        /// </summary>
        /// <param name="bucket">bucket to delete</param>
        /// <returns>delete has been accepted</returns>
        public Task DeleteBucketAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return DeleteBucketAsync(bucket.Id);
        }

        /// <summary>
        /// Clone a bucket.
        /// </summary>
        /// <param name="clonedName">name of cloned bucket</param>
        /// <param name="bucketId">ID of bucket to clone</param>
        /// <returns>cloned bucket</returns>
        public async Task<Bucket> CloneBucketAsync(string clonedName, string bucketId)
        {
            Arguments.CheckNonEmptyString(clonedName, nameof(clonedName));
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            var bucket = await FindBucketByIdAsync(bucketId).ConfigureAwait(false);
            return await CloneBucketAsync(clonedName, bucket).ConfigureAwait(false);
        }

        /// <summary>
        /// Clone a bucket.
        /// </summary>
        /// <param name="clonedName">name of cloned bucket</param>
        /// <param name="bucket">bucket to clone</param>
        /// <returns>cloned bucket</returns>
        public async Task<Bucket> CloneBucketAsync(string clonedName, Bucket bucket)
        {
            Arguments.CheckNonEmptyString(clonedName, nameof(clonedName));
            Arguments.CheckNotNull(bucket, nameof(bucket));

            var cloned = new Bucket(null, clonedName, null, bucket.OrgID, bucket.Rp, bucket.RetentionRules);

            var created = await CreateBucketAsync(cloned).ConfigureAwait(false);

            var labels = await GetLabelsAsync(bucket).ConfigureAwait(false);
            foreach (var label in labels)
            {
                await AddLabelAsync(label, created).ConfigureAwait(false);
            }
            
            return created;
        }

        /// <summary>
        /// Retrieve a bucket.
        /// </summary>
        /// <param name="bucketId">ID of bucket to get</param>
        /// <returns>Bucket Details</returns>
        public Task<Bucket> FindBucketByIdAsync(string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            return _service.GetBucketsIDAsync(bucketId);
        }

        /// <summary>
        /// Retrieve a bucket.
        /// </summary>
        /// <param name="bucketName">Name of bucket to get</param>
        /// <returns>Bucket Details</returns>
        public async Task<Bucket> FindBucketByNameAsync(string bucketName)
        {
            Arguments.CheckNonEmptyString(bucketName, nameof(bucketName));

            var buckets = await _service
                .GetBucketsAsync(null, null, null, null, null, null, bucketName).ConfigureAwait(false);
            
            return buckets._Buckets.FirstOrDefault();
        }

        /// <summary>
        /// List all buckets for specified organization.
        /// </summary>
        /// <param name="organization">filter buckets to a specific organization</param>
        /// <returns>A list of buckets</returns>
        public Task<List<Bucket>> FindBucketsByOrganizationAsync(Organization organization)
        {
            Arguments.CheckNotNull(organization, nameof(organization));

            return FindBucketsByOrgNameAsync(organization.Name);
        }

        /// <summary>
        /// List all buckets for specified orgId.
        /// </summary>
        /// <param name="orgName">filter buckets to a specific organization</param>
        /// <returns>A list of buckets</returns>
        public async Task<List<Bucket>> FindBucketsByOrgNameAsync(string orgName)
        {
            var buckets = await FindBucketsAsync(orgName, new FindOptions()).ConfigureAwait(false);
            return buckets._Buckets;
        }

        /// <summary>
        /// List all buckets.
        /// </summary>
        /// <returns>List all buckets</returns>
        public Task<List<Bucket>> FindBucketsAsync()
        {
            return FindBucketsByOrgNameAsync(null);
        }

        /// <summary>
        /// List all buckets.
        /// </summary>
        /// <param name="findOptions">the find options</param>
        /// <returns>List all buckets</returns>
        public Task<Buckets> FindBucketsAsync(FindOptions findOptions)
        {
            Arguments.CheckNotNull(findOptions, nameof(findOptions));

            return FindBucketsAsync(null, findOptions);
        }

        /// <summary>
        /// List all members of a bucket.
        /// </summary>
        /// <param name="bucket">bucket of the members</param>
        /// <returns>the List all members of a bucket</returns>
        public Task<List<ResourceMember>> GetMembersAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return GetMembersAsync(bucket.Id);
        }

        /// <summary>
        /// List all members of a bucket.
        /// </summary>
        /// <param name="bucketId">ID of bucket to get members</param>
        /// <returns>the List all members of a bucket</returns>
        public async Task<List<ResourceMember>> GetMembersAsync(string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            var members = await _service.GetBucketsIDMembersAsync(bucketId).ConfigureAwait(false);
            return members.Users;
        }

        /// <summary>
        /// Add a bucket member.
        /// </summary>
        /// <param name="member">the member of a bucket</param>
        /// <param name="bucket">the bucket of a member</param>
        /// <returns>created mapping</returns>
        public Task<ResourceMember> AddMemberAsync(User member, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(member, nameof(member));

            return AddMemberAsync(member.Id, bucket.Id);
        }

        /// <summary>
        /// Add a bucket member.
        /// </summary>
        /// <param name="memberId">the ID of a member</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>created mapping</returns>
        public Task<ResourceMember> AddMemberAsync(string memberId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(memberId, nameof(memberId));

            var mapping = new AddResourceMemberRequestBody(memberId);

            return _service.PostBucketsIDMembersAsync(bucketId, mapping);
        }

        /// <summary>
        /// Removes a member from a bucket.
        /// </summary>
        /// <param name="member">the member of a bucket</param>
        /// <param name="bucket">the bucket of a member</param>
        /// <returns>member removed</returns>
        public Task DeleteMemberAsync(User member, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(member, nameof(member));

            return DeleteMemberAsync(member.Id, bucket.Id);
        }

        /// <summary>
        /// Removes a member from a bucket.
        /// </summary>
        /// <param name="memberId">the ID of a member</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>member removed</returns>
        public Task DeleteMemberAsync(string memberId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(memberId, nameof(memberId));

            return _service.DeleteBucketsIDMembersIDAsync(memberId, bucketId);
        }

        /// <summary>
        /// List all owners of a bucket.
        /// </summary>
        /// <param name="bucket">bucket of the owners</param>
        /// <returns>the List all owners of a bucket</returns>
        public Task<List<ResourceOwner>> GetOwnersAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return GetOwnersAsync(bucket.Id);
        }

        /// <summary>
        /// List all owners of a bucket.
        /// </summary>
        /// <param name="bucketId">ID of a bucket to get owners</param>
        /// <returns>the List all owners of a bucket</returns>
        public async Task<List<ResourceOwner>> GetOwnersAsync(string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            var members = await _service.GetBucketsIDOwnersAsync(bucketId).ConfigureAwait(false);
            return members.Users;
        }

        /// <summary>
        /// Add a bucket owner.
        /// </summary>
        /// <param name="owner">the owner of a bucket</param>
        /// <param name="bucket">the bucket of a owner</param>
        /// <returns>created mapping</returns>
        public Task<ResourceOwner> AddOwnerAsync(User owner, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(owner, nameof(owner));

            return AddOwnerAsync(owner.Id, bucket.Id);
        }

        /// <summary>
        /// Add a bucket owner.
        /// </summary>
        /// <param name="ownerId">the ID of a owner</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>created mapping</returns>
        public Task<ResourceOwner> AddOwnerAsync(string ownerId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(ownerId, nameof(ownerId));

            var mapping = new AddResourceMemberRequestBody(ownerId);

            return _service.PostBucketsIDOwnersAsync(bucketId, mapping);
        }

        /// <summary>
        /// Removes a owner from a bucket.
        /// </summary>
        /// <param name="owner">the owner of a bucket</param>
        /// <param name="bucket">the bucket of a owner</param>
        /// <returns>owner removed</returns>
        public Task DeleteOwnerAsync(User owner, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(owner, nameof(owner));

            return DeleteOwnerAsync(owner.Id, bucket.Id);
        }

        /// <summary>
        /// Removes a owner from a bucket.
        /// </summary>
        /// <param name="ownerId">the ID of a owner</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>owner removed</returns>
        public Task DeleteOwnerAsync(string ownerId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(ownerId, nameof(ownerId));

            return _service.DeleteBucketsIDOwnersIDAsync(ownerId, bucketId);
        }

        /// <summary>
        /// List all labels of a bucket.
        /// </summary>
        /// <param name="bucket">bucket of the labels</param>
        /// <returns>the List all labels of a bucket</returns>
        public Task<List<Label>> GetLabelsAsync(Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));

            return GetLabelsAsync(bucket.Id);
        }

        /// <summary>
        /// List all labels of a bucket.
        /// </summary>
        /// <param name="bucketId">ID of a bucket to get labels</param>
        /// <returns>the List all labels of a bucket</returns>
        public async Task<List<Label>> GetLabelsAsync(string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));

            var response = await _service.GetBucketsIDLabelsAsync(bucketId).ConfigureAwait(false);
            return response.Labels;
        }

        /// <summary>
        /// Add a bucket label.
        /// </summary>
        /// <param name="label">the label of a bucket</param>
        /// <param name="bucket">the bucket of a label</param>
        /// <returns>added label</returns>
        public Task<Label> AddLabelAsync(Label label, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(label, nameof(label));

            return AddLabelAsync(label.Id, bucket.Id);
        }

        /// <summary>
        /// Add a bucket label.
        /// </summary>
        /// <param name="labelId">the ID of a label</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>added label</returns>
        public async Task<Label> AddLabelAsync(string labelId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(labelId, nameof(labelId));

            var mapping = new LabelMapping(labelId);

            var response = await _service.PostBucketsIDLabelsAsync(bucketId, mapping).ConfigureAwait(false);
            return response.Label;
        }

        /// <summary>
        /// Removes a label from a bucket.
        /// </summary>
        /// <param name="label">the label of a bucket</param>
        /// <param name="bucket">the bucket of a owner</param>
        /// <returns>delete has been accepted</returns>
        public Task DeleteLabelAsync(Label label, Bucket bucket)
        {
            Arguments.CheckNotNull(bucket, nameof(bucket));
            Arguments.CheckNotNull(label, nameof(label));

            return DeleteLabelAsync(label.Id, bucket.Id);
        }

        /// <summary>
        /// Removes a label from a bucket.
        /// </summary>
        /// <param name="labelId">the ID of a label</param>
        /// <param name="bucketId">the ID of a bucket</param>
        /// <returns>delete has been accepted</returns>
        public Task DeleteLabelAsync(string labelId, string bucketId)
        {
            Arguments.CheckNonEmptyString(bucketId, nameof(bucketId));
            Arguments.CheckNonEmptyString(labelId, nameof(labelId));

            return _service.DeleteBucketsIDLabelsIDAsync(bucketId, labelId);
        }

        private Task<Buckets> FindBucketsAsync(string orgName, FindOptions findOptions)
        {
            Arguments.CheckNotNull(findOptions, nameof(findOptions));

            return _service.GetBucketsAsync(null, findOptions.Offset, findOptions.Limit, after: findOptions.After,org: orgName);
        }
    }
}