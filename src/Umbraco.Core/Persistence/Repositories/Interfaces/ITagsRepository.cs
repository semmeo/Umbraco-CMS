using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Umbraco.Core.Persistence.Repositories
{
    public interface ITagsRepository : IRepositoryQueryable<int, ITag>
    {
        IEnumerable<TaggedEntity> GetTaggedEntitiesByTagGroup(TaggableObjectTypes objectType, string tagGroup);

        IEnumerable<TaggedEntity> GetTaggedEntitiesByTag(TaggableObjectTypes objectType, string tag, string tagGroup = null);

        /// <summary>
        /// Returns all tags for an entity type (content/media/member)
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="group">Optional group</param>
        /// <returns></returns>
        IEnumerable<ITag> GetTagsForEntityType(TaggableObjectTypes objectType, string group = null);

        /// <summary>
        /// Returns all tags that exist on the content item - Content/Media/Member
        /// </summary>
        /// <param name="contentId">The content item id to get tags for</param>
        /// <param name="group">Optional group</param>
        /// <returns></returns>
        IEnumerable<ITag> GetTagsForEntity(int contentId, string group = null);

        /// <summary>
        /// Returns all tags that exist on the content item for the property specified - Content/Media/Member
        /// </summary>
        /// <param name="contentId">The content item id to get tags for</param>
        /// <param name="propertyTypeAlias">The property alias to get tags for</param>
        /// <param name="group">Optional group</param>
        /// <returns></returns>
        IEnumerable<ITag> GetTagsForProperty(int contentId, string propertyTypeAlias, string group = null);

        /// <summary>
        /// Assigns the given tags to a content item's property
        /// </summary>
        /// <param name="contentId"></param>
        /// <param name="propertyTypeId"></param>
        /// <param name="tags">The tags to assign</param>
        /// <param name="replaceTags">
        /// If set to true, this will replace all tags with the given tags, 
        /// if false this will append the tags that already exist for the content item
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This can also be used to remove all tags from a property by specifying replaceTags = true and an empty tag list.
        /// </remarks>
        void AssignTagsToProperty(int contentId, int propertyTypeId, IEnumerable<ITag> tags, bool replaceTags);

        /// <summary>
        /// Removes any of the given tags from the property association
        /// </summary>
        /// <param name="contentId"></param>
        /// <param name="propertyTypeId"></param>
        /// <param name="tags">The tags to remove from the property</param>
        void RemoveTagsFromProperty(int contentId, int propertyTypeId, IEnumerable<ITag> tags);
    }
}